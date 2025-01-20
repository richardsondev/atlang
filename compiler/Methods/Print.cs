using AtLangCompiler.ILEmitter;
using System.Reflection.Emit;

namespace AtLangCompiler.Methods;

internal class PrintStatement : ASTNode
{
    public ASTNode Expr { get; }
    public PrintStatement(ASTNode expr) { Expr = expr; }
}

[ParserFor(TokenType.PRINT)]
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
    private readonly LocalBuilder dictLocal;
    private readonly ILMethodEmitterManager emitter;

    public Print(ILGenerator il, LocalBuilder dictLocal, ILMethodEmitterManager emitter)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.dictLocal = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));
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
