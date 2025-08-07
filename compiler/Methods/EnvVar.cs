using AtLangCompiler.ILEmitter;
using System.Reflection;
using System.Reflection.Emit;

namespace AtLangCompiler.Methods;

internal class GetEnvToken : ILexerTokenConfig
{
    public IReadOnlyDictionary<string, TokenType> TokenStrings => new Dictionary<string, TokenType>
    {
        { "@getEnv", TokenType.GETENV }
    };
}

internal class EnvVarAssignment : ASTNode
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

[ParserFor(TokenType.GETENV, inputTokens: 1)]
internal class EnvironmentStatementParser : IStatementParser
{
    public ASTNode ParseStatement(Parser parser)
    {
        parser.Eat(TokenType.GETENV);
        parser.Eat(TokenType.LPAREN);
        parser.Eat(TokenType.AT);
        string envName = parser.current.Text;
        parser.Eat(TokenType.IDENT);
        parser.Eat(TokenType.RPAREN);
        return new EnvVarAssignment(parser.varName, envName, null);
    }
}

[EmitterFor(typeof(EnvVarAssignment))]
internal class EnvVar : IMethodEmitter<EnvVarAssignment>
{
    private readonly ILGenerator il;
    private readonly ILMethodEmitterManager emitter;
    public EnvVar(ILGenerator il, ILMethodEmitterManager emitter)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.emitter = emitter ?? throw new ArgumentNullException(nameof(emitter));
    }

    public void EmitIL(EnvVarAssignment node)
    {
        LocalBuilder varLocal = emitter.GetOrDeclareLocal(node.VarName, typeof(string));

        if (node.EnvVarName != null)
        {
            // Environment.GetEnvironmentVariable(...) ?? ""
            System.Reflection.MethodInfo getEnvMI = typeof(Environment).GetMethod(nameof(Environment.GetEnvironmentVariable), [typeof(string)])!;
            il.Emit(OpCodes.Ldstr, node.EnvVarName);
            il.Emit(OpCodes.Call, getEnvMI);

            // if null => ""
            il.Emit(OpCodes.Dup);
            Label labelNotNull = il.DefineLabel();
            Label labelEnd = il.DefineLabel();
            il.Emit(OpCodes.Brtrue_S, labelNotNull);
            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ldstr, string.Empty);
            il.MarkLabel(labelNotNull);
            il.MarkLabel(labelEnd);
        }
        else
        {
            il.Emit(OpCodes.Ldstr, node.StrValue ?? string.Empty);
        }

        il.Emit(OpCodes.Stloc, varLocal);
    }
}
