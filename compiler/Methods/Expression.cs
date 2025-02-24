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
    private readonly LocalBuilder dictLocal;
    private readonly ILMethodEmitterManager emitter;

    public Expression(ILGenerator il, LocalBuilder dictLocal, ILMethodEmitterManager emitter)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.dictLocal = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));
        this.emitter = emitter ?? throw new ArgumentNullException(nameof(emitter));
    }

    public void EmitIL(ASTNode expr)
    {
        // Evaluate VarReference, StringLiteral, or BinaryExpression
        if (expr is VarReference vr)
        {
            // dict[varName]
            il.Emit(OpCodes.Ldloc, dictLocal);
            il.Emit(OpCodes.Ldstr, vr.Name);

            System.Reflection.MethodInfo dictGetItem = typeof(Dictionary<string, object>)
                .GetProperty("Item")!
                .GetGetMethod()!;
            il.Emit(OpCodes.Callvirt, dictGetItem);
            il.Emit(OpCodes.Isinst, typeof(string));

            // if null => ""
            Label labelNotNull = il.DefineLabel();
            Label labelEnd = il.DefineLabel();
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Brtrue_S, labelNotNull);
            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ldstr, string.Empty);
            il.MarkLabel(labelNotNull);
            il.MarkLabel(labelEnd);
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
