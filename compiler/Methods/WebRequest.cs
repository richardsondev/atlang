using AtLangCompiler.ILEmitter;
using System.Net;
using System.Reflection.Emit;

namespace AtLangCompiler.Methods;

internal class WebRequestToken : ILexerTokenConfig
{
    public IReadOnlyDictionary<string, TokenType> TokenStrings => new Dictionary<string, TokenType>
    {
        { "@getWeb", TokenType.GETWEB },
        { "@postWeb", TokenType.POSTWEB }
    };
}

internal class WebRequestAssign : ASTNode
{
    public string VarName { get; }
    public string Method { get; }
    public string UrlVar { get; }
    public string? BodyVar { get; }
    public string? PostVar { get; }

    public WebRequestAssign(string varName, string method, string url, string? body, string? post)
    {
        VarName = varName;
        Method = method;
        UrlVar = url;
        BodyVar = body;
        PostVar = post;
    }
}

[ParserFor(TokenType.GETWEB, inputTokens: 1)]
[ParserFor(TokenType.POSTWEB, inputTokens: 2)]
internal class WebRequestParser : IStatementParser
{
    public ASTNode ParseStatement(Parser parser)
    {
        if (parser.current.Type == TokenType.GETWEB)
        {
            parser.Eat(TokenType.GETWEB);
            parser.Eat(TokenType.LPAREN);
            parser.Eat(TokenType.AT);
            string url = parser.current.Text;
            parser.Eat(TokenType.IDENT);
            parser.Eat(TokenType.RPAREN);
            return new WebRequestAssign(parser.varName, "GET", url, null, null);
        }
        else if (parser.current.Type == TokenType.POSTWEB)
        {
            parser.Eat(TokenType.POSTWEB);
            parser.Eat(TokenType.LPAREN);
            parser.Eat(TokenType.AT);
            string url = parser.current.Text;
            parser.Eat(TokenType.IDENT);
            parser.Eat(TokenType.AT);
            string postData = parser.current.Text;
            parser.Eat(TokenType.IDENT);
            parser.Eat(TokenType.RPAREN);
            return new WebRequestAssign(parser.varName, "POST", url, null, postData);
        }
        else
        {
            throw new ArgumentOutOfRangeException($"Unknown token {parser.current.Type}");
        }
    }
}

[EmitterFor(typeof(WebRequestAssign))]
internal class WebRequest : IMethodEmitter<WebRequestAssign>
{
    private readonly ILGenerator il;
    private readonly LocalBuilder dictLocal;

    public WebRequest(ILGenerator il, LocalBuilder dictLocal)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.dictLocal = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));
    }

    public void EmitIL(WebRequestAssign node)
    {
        // dict[node.VarName] = new WebClient().DownloadString( dict[node.URL] )  (for GET)
        // or dict[node.VarName] = new WebClient().UploadString( dict[node.URL], dict[node.BodyVar] )  (for POST, if body is also a variable)

        // 1) Load dictLocal
        il.Emit(OpCodes.Ldloc, dictLocal);

        // 2) Push node.VarName (the key in the dictionary where we store the response)
        il.Emit(OpCodes.Ldstr, node.VarName);

        // 3) Create new WebClient
        il.Emit(OpCodes.Newobj, typeof(WebClient).GetConstructor(Type.EmptyTypes)!);

        // 4) Because node.URL is a variable name, we must do a dictionary lookup to get the actual URL string:
        il.Emit(OpCodes.Ldloc, dictLocal);
        il.Emit(OpCodes.Ldstr, node.UrlVar);  // the *name* of the variable
        System.Reflection.MethodInfo dictGetItem = typeof(Dictionary<string, object>)
            .GetProperty("Item")!
            .GetGetMethod()!;
        il.Emit(OpCodes.Isinst, typeof(string));
        il.Emit(OpCodes.Callvirt, dictGetItem); // returns the actual URL string

        if (node.Method.Equals(nameof(HttpMethod.Get), StringComparison.OrdinalIgnoreCase))
        {
            // WebClient.DownloadString(string)
            System.Reflection.MethodInfo downloadString = typeof(WebClient).GetMethod(nameof(WebClient.DownloadString), [typeof(string)])!;
            il.Emit(OpCodes.Callvirt, downloadString);
        }
        else if (node.Method.Equals(nameof(HttpMethod.Post), StringComparison.OrdinalIgnoreCase))
        {
            il.Emit(OpCodes.Ldloc, dictLocal);
            il.Emit(OpCodes.Ldstr, node.PostVar!);
            il.Emit(OpCodes.Callvirt, dictGetItem);  // now the stack has: [webClient, urlString, bodyString]

            // WebClient.UploadString(string url, string data)
            System.Reflection.MethodInfo uploadString = typeof(WebClient)
                .GetMethod(nameof(WebClient.UploadString), [typeof(string), typeof(string)])!;
            il.Emit(OpCodes.Callvirt, uploadString);
        }
        else
        {
            // If the method is unknown, push a dummy string or error message
            il.Emit(OpCodes.Pop); // discard the WebClient instance
            il.Emit(OpCodes.Ldstr, $"Unsupported HTTP method: {node.Method}");
        }

        // At this point, the top of the stack is the response string (or error message).
        // 5) Store it in dict[node.VarName]
        System.Reflection.MethodInfo dictSetItem = typeof(Dictionary<string, object>)
            .GetProperty("Item")!
            .GetSetMethod()!;
        il.Emit(OpCodes.Isinst, typeof(string));
        il.Emit(OpCodes.Callvirt, dictSetItem);
    }
}
