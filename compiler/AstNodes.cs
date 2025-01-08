public abstract class ASTNode { }

public class EnvVarAssignment : ASTNode
{
    public string VarName { get; }
    public string? EnvVarName { get; }
    public string? StrValue { get; }

    public EnvVarAssignment(string varName, string? envVarName, string? strValue)
    {
        VarName = varName;
        EnvVarName = envVarName;
        StrValue = strValue;
    }
}

public class WebRequestAssign : ASTNode
{
    public string VarName { get; }
    public string Method { get; }
    public string UrlVar { get; }
    public string BodyVar { get; }
    public string PostVar { get; }

    public WebRequestAssign(string varName, string method, string url, string? body, string? post)
    {
        VarName = varName;
        Method = method;
        UrlVar = url;
        BodyVar = body ?? throw new ArgumentNullException(nameof(body));
        PostVar = post ?? throw new ArgumentNullException(nameof(post));
    }
}

public class StartServerAssign : ASTNode
{
    public string ServerRootPath { get; }
    public string Port { get; }

    public StartServerAssign(string serverRootPath, string port)
    {
        ServerRootPath = serverRootPath;
        Port = port;
    }
}

public class PrintStatement : ASTNode
{
    public ASTNode Expr { get; }
    public PrintStatement(ASTNode expr) { Expr = expr; }
}

public class IfStatement : ASTNode
{
    public ASTNode LeftExpr { get; }
    public ASTNode RightExpr { get; }
    public List<ASTNode> IfBody { get; }
    public List<ASTNode> ElseBody { get; }

    public IfStatement(ASTNode left, ASTNode right, List<ASTNode> ifBody, List<ASTNode> elseBody)
    {
        LeftExpr = left; RightExpr = right;
        IfBody = ifBody; ElseBody = elseBody;
    }
}

public class BinaryExpression : ASTNode
{
    public ASTNode Left { get; }
    public string Op { get; }
    public ASTNode Right { get; }
    public BinaryExpression(ASTNode left, string op, ASTNode right)
    {
        Left = left; Op = op; Right = right;
    }
}

public class VarReference : ASTNode
{
    public string Name { get; }
    public VarReference(string name) { Name = name; }
}

public class StringLiteral : ASTNode
{
    public string Value { get; }
    public StringLiteral(string value) { Value = value; }
}
