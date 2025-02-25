using AtLangCompiler.ILEmitter;
using AtLangCompiler.Methods;
using System.Reflection.Emit;
using System.Reflection;

namespace AtLangCompiler.Methods
{
    internal class VarAssignment : ASTNode
    {
        public string VarName { get; }
        public object Value { get; }

        public VarAssignment(string varName, object value)
        {
            VarName = varName;
            Value = value;
        }
    }

    [ParserFor(TokenType.IDENT)]
    internal class VarParser : IStatementParser
    {
        public ASTNode ParseStatement(Parser parser)
        {
            parser.Eat(TokenType.AT);
            var s = parser.current.Text;
            parser.Eat(TokenType.IDENT);
            return new VarReference(s);
        }
    }
}

[EmitterFor(typeof(VarAssignment))]
internal class Var : IMethodEmitter<VarAssignment>
{
    private readonly ILGenerator il;
    private readonly LocalBuilder dictLocal;

    public Var(ILGenerator il, LocalBuilder dictLocal)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.dictLocal = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));
    }

    public void EmitIL(VarAssignment node)
    {
        // dict[varName] = ...
        il.Emit(OpCodes.Ldloc, dictLocal);
        il.Emit(OpCodes.Ldstr, node.VarName);

        if (node.Value is string stringValue)
        {
            il.Emit(OpCodes.Ldstr, stringValue);
        }
        else if (node.Value is long longValue)
        {
            il.Emit(OpCodes.Ldc_I8, longValue);
            il.Emit(OpCodes.Box, typeof(long)); // Box long to object
        }
        else
        {
            throw new InvalidOperationException($"Unsupported value type: {node.Value?.GetType()}");
        }

        MethodInfo dictSetItem = typeof(Dictionary<string, object>)
            .GetProperty("Item")!
            .GetSetMethod()!;
        il.Emit(OpCodes.Callvirt, dictSetItem);
    }
}
