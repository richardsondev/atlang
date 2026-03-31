namespace AtLangCompiler;

public enum TokenType
{
    AT, IDENT, EQUAL, GETENV, LPAREN, RPAREN, LBRACE, RBRACE,
    STRING, NUMBER, PLUS, IF, ELSE, PRINT, EQEQ, EOF,
    GETWEB, POSTWEB, STARTSERVER, EXIT
}

public enum TokenKind
{
    TEXT, NUMBER
}

public class Token
{
    public TokenType Type { get; }
    public TokenKind Kind { get; }
    private readonly string? text;
    private readonly long? number;

    public Token(TokenType type, string text)
    {
        Type = type;
        Kind = TokenKind.TEXT;
        this.text = text;
    }

    public Token(TokenType type, long number)
    {
        Type = type;
        Kind = TokenKind.NUMBER;
        this.number = number;
    }

    public string Text => Kind == TokenKind.TEXT
        ? text!
        : throw new InvalidOperationException($"Attempted to access Text on a {Kind} token.");

    public long Number => Kind == TokenKind.NUMBER
        ? number!.Value
        : throw new InvalidOperationException($"Attempted to access Number on a {Kind} token.");
}
