using AtLangCompiler.ILEmitter;
using System.Reflection.Emit;

namespace AtLangCompiler.Methods;

internal class IfStatement : ASTNode
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

[ParserFor(TokenType.IF)]
internal class ConditionalStatementParser : IStatementParser
{
    public ASTNode ParseStatement(Parser parser)
    {
        parser.Eat(TokenType.IF);
        parser.Eat(TokenType.LPAREN);
        ASTNode left = parser.ParseExpression();

        if (parser.current.Type == TokenType.EQEQ)
        {
            parser.Eat(TokenType.EQEQ);
        }
        else
        {
            throw new Exception("Only == is supported.");
        }

        ASTNode right = parser.ParseExpression();
        parser.Eat(TokenType.RPAREN);
        parser.Eat(TokenType.LBRACE);
        List<ASTNode> ifBody = new List<ASTNode>();
        while (parser.current.Type != TokenType.RBRACE && parser.current.Type != TokenType.EOF)
        {
            ASTNode? s = parser.ParseStatement();
            if (s != null) ifBody.Add(s);
        }
        parser.Eat(TokenType.RBRACE);

        List<ASTNode> elseBody = new List<ASTNode>();
        if (parser.current.Type == TokenType.ELSE)
        {
            parser.Eat(TokenType.ELSE);
            parser.Eat(TokenType.LBRACE);
            while (parser.current.Type != TokenType.RBRACE && parser.current.Type != TokenType.EOF)
            {
                ASTNode? s = parser.ParseStatement();
                if (s != null) elseBody.Add(s);
            }
            parser.Eat(TokenType.RBRACE);
        }
        return new IfStatement(left, right, ifBody, elseBody);
    }
}

[EmitterFor(typeof(IfStatement))]
internal class Conditional : IMethodEmitter<IfStatement>
{
    private readonly ILGenerator il;
    private readonly ILMethodEmitterManager emitter;

    public Conditional(ILGenerator il, ILMethodEmitterManager emitter)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.emitter = emitter ?? throw new ArgumentNullException(nameof(emitter));
    }

    public void EmitIL(IfStatement node)
    {
        // if (EvalExpr(Left) == EvalExpr(Right)) { IfBody } else { ElseBody }
        emitter.EmitStatement(node.LeftExpr);
        emitter.EmitStatement(node.RightExpr);

        // string.Equals(string, StringComparison.Ordinal)
        System.Reflection.MethodInfo strEquals = typeof(string).GetMethod("Equals", [typeof(string), typeof(StringComparison)])!;
        Label labelElse = il.DefineLabel();
        Label labelEnd = il.DefineLabel();

        il.Emit(OpCodes.Ldc_I4, (int)StringComparison.Ordinal);
        il.Emit(OpCodes.Call, strEquals);
        il.Emit(OpCodes.Brfalse, labelElse);

        // If-body
        foreach (ASTNode st in node.IfBody)
        {
            emitter.EmitStatement(st);
        }

        il.Emit(OpCodes.Br, labelEnd);

        // Else-body
        il.MarkLabel(labelElse);
        foreach (ASTNode st in node.ElseBody)
        {
            emitter.EmitStatement(st);
        }

        il.MarkLabel(labelEnd);
    }
}
