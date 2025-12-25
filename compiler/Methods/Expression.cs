using AtLangCompiler.ILEmitter;
using System.Reflection;
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

internal class NumberLiteral : ASTNode
{
    public long Value { get; }
    public NumberLiteral(long value) { Value = value; }
}

[EmitterFor(typeof(VarReference))]
[EmitterFor(typeof(StringLiteral))]
[EmitterFor(typeof(NumberLiteral))]
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
        if (expr is VarReference vr)
        {
            // Load the dictionary and key
            il.Emit(OpCodes.Ldloc, dictLocal);
            il.Emit(OpCodes.Ldstr, vr.Name);

            // Get dictionary value
            MethodInfo dictGetItem = typeof(Dictionary<string, object>)
                .GetProperty("Item")!
                .GetGetMethod()!;
            il.Emit(OpCodes.Callvirt, dictGetItem);

            // Duplicate the retrieved value for type checking
            il.Emit(OpCodes.Dup);

            Label labelIsLong = il.DefineLabel();
            Label labelIsString = il.DefineLabel();
            Label labelNotNull = il.DefineLabel();
            Label labelEnd = il.DefineLabel();

            // Check if the value is a long (Int64)
            il.Emit(OpCodes.Isinst, typeof(long));
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Brtrue_S, labelIsLong); // If it's a long, jump to long handling

            // Check if the value is a string
            il.Emit(OpCodes.Pop); // Remove the failed `long` check result
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Isinst, typeof(string));
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Brtrue_S, labelIsString); // If it's a string, jump to string handling

            // If null, replace with an empty string
            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ldstr, string.Empty);
            il.Emit(OpCodes.Br_S, labelEnd); // Jump to end

            // Handle long case
            il.MarkLabel(labelIsLong);
            il.Emit(OpCodes.Unbox_Any, typeof(long)); // Extract long value
            il.Emit(OpCodes.Br_S, labelEnd);

            // Handle string case
            il.MarkLabel(labelIsString);
            il.Emit(OpCodes.Br_S, labelEnd);

            il.MarkLabel(labelEnd);
        }
        else if (expr is StringLiteral sl)
        {
            il.Emit(OpCodes.Ldstr, sl.Value);
        }
        else if (expr is NumberLiteral nl)
        {
            il.Emit(OpCodes.Ldc_I8, nl.Value);
        }
        else if (expr is BinaryExpression be)
        {
            // left + right
            EmitIL(be.Left);
            EmitIL(be.Right);
            if (be.Op == "+")
            {
                // TODO: handle number varreference
                if ((be.Left is StringLiteral && be.Right is StringLiteral) ||
                    (be.Left is StringLiteral && be.Right is VarReference) ||
                    (be.Left is VarReference && be.Right is StringLiteral) ||
                    (be.Left is VarReference && be.Right is VarReference))
                {
                    MethodInfo concat = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
                    il.Emit(OpCodes.Call, concat);
                }
                else if (be.Left is NumberLiteral && be.Right is NumberLiteral)
                {
                    il.Emit(OpCodes.Add);
                }
                else
                {
                    throw new InvalidOperationException($"Unable to add variables of different types. Type 1: {be.Left.GetType()}, Type 2: {be.Right.GetType()}");
                }
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
