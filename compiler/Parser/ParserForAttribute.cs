namespace AtLangCompiler;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class ParserForAttribute : Attribute
{
    public TokenType TokenType { get; }

    public ParserForAttribute(TokenType tokenType)
    {
        this.TokenType = tokenType;
    }
}
