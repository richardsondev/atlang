using AtLangCompiler.ILEmitter;
using System.Reflection.Emit;

namespace AtLangCompiler.Methods;

internal class BinaryExpression : ASTNode
{
    public ASTNode Left { get; }
    public string Op { get; }
    public ASTNode Right { get; }
    public BinaryExpression(ASTNode left, string op, ASTNode right)
    {
        Left = left; Op = op; Right = right;
    }
}

internal class VarReference : ASTNode
{
    public string Name { get; }
    public VarReference(string name) { Name = name; }
}

internal class StringLiteral : ASTNode
{
    public string Value { get; }
    public StringLiteral(string value) { Value = value; }
}

[EmitterFor(typeof(VarReference))]
[EmitterFor(typeof(StringLiteral))]
[EmitterFor(typeof(BinaryExpression))]
internal class Expression : IMethodEmitter<ASTNode>
{
    private readonly ILGenerator il;
    private readonly ILMethodEmitterManager emitter;

    public Expression(ILGenerator il, ILMethodEmitterManager emitter)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.emitter = emitter ?? throw new ArgumentNullException(nameof(emitter));
    }

    public void EmitIL(ASTNode expr)
    {
        // Evaluate VarReference, StringLiteral, or BinaryExpression
        if (expr is VarReference vr)
        {
            il.Emit(OpCodes.Ldloc, emitter.GetLocal(vr.Name));
        }
        else if (expr is StringLiteral sl)
        {
            il.Emit(OpCodes.Ldstr, sl.Value);
        }
        else if (expr is BinaryExpression be)
        {
            // left + right
            EmitIL(be.Left);
            EmitIL(be.Right);
            if (be.Op == "+")
            {
                System.Reflection.MethodInfo concat = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
                il.Emit(OpCodes.Call, concat);
            }
            else
            {
                throw new Exception($"Unsupported operator: {be.Op}");
            }
        }
        else
        {
            throw new Exception($"Unknown expression type: {expr.GetType().Name}");
        }
    }
}
