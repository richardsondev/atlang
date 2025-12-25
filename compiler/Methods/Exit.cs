using AtLangCompiler.ILEmitter;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace AtLangCompiler.Methods;

/// <summary>
/// Token configuration for exit statements.
/// </summary>
internal class ExitToken : ILexerTokenConfig
{
    /// <summary>
    /// Gets the mapping of token strings to <see cref="TokenType"/> values.
    /// </summary>
    public IReadOnlyDictionary<string, TokenType> TokenStrings => new Dictionary<string, TokenType>
    {
        { "@exit", TokenType.EXIT }
    };
}

/// <summary>
/// Represents an exit code expression in the abstract syntax tree.
/// </summary>
internal class ExitCodeStatement : ASTNode
{
    /// <summary>
    /// Gets the expression that, when evaluated, produces the exit code string.
    /// </summary>
    public ASTNode Expr { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExitCodeStatement"/> class.
    /// </summary>
    /// <param name="expr">The expression to evaluate for the exit code string.</param>
    public ExitCodeStatement(ASTNode expr) => Expr = expr;
}

/// <summary>
/// Parser for exit code statements.
/// </summary>
[ParserFor(TokenType.EXIT, inputTokens: 1)]
internal class ExitCodeStatementParser : IStatementParser
{
    /// <summary>
    /// Parses an exit code statement.
    /// </summary>
    /// <param name="parser">The parser instance.</param>
    /// <returns>An <see cref="ASTNode"/> representing the exit code statement.</returns>
    public ASTNode ParseStatement(Parser parser)
    {
        parser.Eat(TokenType.EXIT);
        parser.Eat(TokenType.LPAREN);
        ASTNode expr = parser.ParseExpression();
        parser.Eat(TokenType.RPAREN);
        return new ExitCodeStatement(expr);
    }
}

/// <summary>
/// IL emitter for exit code statements.
/// </summary>
[EmitterFor(typeof(ExitCodeStatement))]
internal class Exit : IMethodEmitter<ExitCodeStatement>
{
    private readonly ILGenerator il;
    private readonly LocalBuilder dictLocal;
    private readonly ILMethodEmitterManager emitter;

    /// <summary>
    /// Initializes a new instance of the <see cref="Exit"/> class.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator"/> instance used for emitting IL code.</param>
    /// <param name="dictLocal">The local variable holding the runtime dictionary.</param>
    /// <param name="emitter">The <see cref="ILMethodEmitterManager"/> used to emit sub-expressions.</param>
    public Exit(ILGenerator il, LocalBuilder dictLocal, ILMethodEmitterManager emitter)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.dictLocal = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));
        this.emitter = emitter ?? throw new ArgumentNullException(nameof(emitter));
    }

    /// <summary>
    /// Emits IL code to retrieve the exit code string from the runtime context,
    /// and clamps the value between 0 and 255, and return it.
    /// If parsing fails, returns 255.
    /// </summary>
    /// <param name="node">
    /// The <see cref="ExitCodeStatement"/> node containing the expression that provides the exit code string.
    /// </param>
    /// <remarks>
    /// The emitted IL expects that <see cref="ILMethodEmitterManager.EmitStatement(ASTNode)"/> will push a <see cref="string"/>
    /// onto the evaluation stack.
    /// </remarks>
    public void EmitIL(ExitCodeStatement node)
    {
        // Clamp between 0 and 255 for POSIX systems.
        const long minExit = 0;
        const long maxExit = 255;

        // Emit IL for the expression that pushes the exit code number onto the stack.
        emitter.EmitStatement(node.Expr);

        // Ensure the expression is treated as a long
        il.Emit(OpCodes.Conv_I8);

        // Clamp the value between minExit and maxExit.
        il.Emit(OpCodes.Ldc_I8, minExit);
        MethodInfo maxMethod = typeof(Math).GetMethod(nameof(Math.Max), new[] { typeof(long), typeof(long) })!;
        il.Emit(OpCodes.Call, maxMethod);

        il.Emit(OpCodes.Ldc_I8, maxExit);
        MethodInfo minMethod = typeof(Math).GetMethod(nameof(Math.Min), new[] { typeof(long), typeof(long) })!;
        il.Emit(OpCodes.Call, minMethod);

        // Convert the long on the stack to an int (POSIX exit code)
        il.Emit(OpCodes.Conv_I4);

        // Exit the program using Environment.Exit
        MethodInfo exitMethod = typeof(Environment).GetMethod(nameof(Environment.Exit), new[] { typeof(int) })!;
        il.Emit(OpCodes.Call, exitMethod);

        // Return
        il.Emit(OpCodes.Ret);
    }
}
