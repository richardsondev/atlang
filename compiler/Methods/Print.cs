using AtLangCompiler.ILEmitter;
using System.Reflection.Emit;

namespace AtLangCompiler.Methods;

internal class PrintToken : ILexerTokenConfig
{
    public IReadOnlyDictionary<string, TokenType> TokenStrings => new Dictionary<string, TokenType>
    {
        { "@print", TokenType.PRINT }
    };
}

internal class PrintStatement : ASTNode
{
    public ASTNode Expr { get; }
    public PrintStatement(ASTNode expr) { Expr = expr; }
}

[ParserFor(TokenType.PRINT, inputTokens: 1)]
internal class PrintStatementParser : IStatementParser
{
    public ASTNode ParseStatement(Parser parser)
    {
        parser.Eat(TokenType.PRINT);
        parser.Eat(TokenType.LPAREN);
        ASTNode expr = parser.ParseExpression();
        parser.Eat(TokenType.RPAREN);
        return new PrintStatement(expr);
    }
}

[EmitterFor(typeof(PrintStatement))]
internal class Print : IMethodEmitter<PrintStatement>
{
    private readonly ILGenerator il;
    private readonly ILMethodEmitterManager emitter;

    public Print(ILGenerator il, ILMethodEmitterManager emitter)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.emitter = emitter ?? throw new ArgumentNullException(nameof(emitter));
    }

    public void EmitIL(PrintStatement node)
    {
        // Console.Out.WriteLine( Evaluate(ps.Expr) )
        il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
        emitter.EmitStatement(node.Expr);
        il.Emit(OpCodes.Callvirt,
            typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);
    }
}
