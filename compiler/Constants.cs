public enum TokenType
{
    AT, IDENT, EQUAL, GETENV, LPAREN, RPAREN, LBRACE, RBRACE,
    STRING, PLUS, IF, ELSE, PRINT, EQEQ, EOF, GETWEB, POSTWEB, STARTSERVER
}

public class Token
{
    public TokenType Type { get; }
    public string Text { get; }
    public Token(TokenType type, string text) { Type = type; Text = text; }
}
