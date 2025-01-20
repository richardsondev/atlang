namespace AtLangCompiler
{
    public interface ILexerTokenConfig
    {
        IReadOnlyDictionary<string, TokenType> TokenStrings { get; }
    }
}
