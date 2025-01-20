namespace AtLangCompiler;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class ParserForAttribute : Attribute
{
    public TokenType TokenType { get; }
    public short InputTokens { get; }
    public string InputSeparator { get; }
    public bool HasBody { get; }
    public TokenType? PrerequisiteToken { get; }

    public ParserForAttribute(TokenType tokenType,
        short inputTokens = 0,
        string inputSeparator = ",",
        bool hasBody = false,
        TokenType prerequisiteToken = TokenType.AT)
    {
        this.TokenType = tokenType;
        this.InputTokens = inputTokens;
        this.InputSeparator = inputSeparator;
        this.HasBody = hasBody;
        this.PrerequisiteToken = prerequisiteToken == TokenType.AT ? null : prerequisiteToken;
    }
}
