using System.Text.RegularExpressions;

public class Lexer
{
    private readonly string _text;
    private int _pos;

    public Lexer(string text) { _text = text; _pos = 0; }

    private char Current => _pos < _text.Length ? _text[_pos] : '\0';

    public Token NextToken()
    {
        // Skip whitespace
        while (_pos < _text.Length && char.IsWhiteSpace(Current))
            _pos++;

        if (_pos >= _text.Length)
            return new Token(TokenType.EOF, string.Empty);

        var rest = _text.Substring(_pos);

        if (rest.StartsWith("@if"))
        {
            _pos += 3;
            return new Token(TokenType.IF, "@if");
        }
        if (rest.StartsWith("@else"))
        {
            _pos += 5;
            return new Token(TokenType.ELSE, "@else");
        }
        if (rest.StartsWith("@print"))
        {
            _pos += 6;
            return new Token(TokenType.PRINT, "@print");
        }
        if (rest.StartsWith("getEnv"))
        {
            _pos += 6;
            return new Token(TokenType.GETENV, "getEnv");
        }
        if (rest.StartsWith("getWeb"))
        {
            _pos += 6;
            return new Token(TokenType.GETWEB, "getWeb");
        }
        if (rest.StartsWith("postWeb"))
        {
            _pos += 7;
            return new Token(TokenType.POSTWEB, "postWeb");
        }
        if (rest.StartsWith("startServer"))
        {
            _pos += 11;
            return new Token(TokenType.STARTSERVER, "startServer");
        }
        // ==
        if (_pos + 1 < _text.Length && Current == '=' && _text[_pos + 1] == '=')
        {
            _pos += 2;
            return new Token(TokenType.EQEQ, "==");
        }

        // single-char tokens
        switch (Current)
        {
            case '@':
                _pos++;
                return new Token(TokenType.AT, "@");
            case '=':
                _pos++;
                return new Token(TokenType.EQUAL, "=");
            case '+':
                _pos++;
                return new Token(TokenType.PLUS, "+");
            case '(':
                _pos++;
                return new Token(TokenType.LPAREN, "(");
            case ')':
                _pos++;
                return new Token(TokenType.RPAREN, ")");
            case '{':
                _pos++;
                return new Token(TokenType.LBRACE, "{");
            case '}':
                _pos++;
                return new Token(TokenType.RBRACE, "}");
            case '"':
                _pos++;
                int start = _pos;
                while (_pos < _text.Length && _text[_pos] != '"') _pos++;
                string strVal = _text.Substring(start, _pos - start);
                if (_pos < _text.Length) _pos++; // skip closing quote
                return new Token(TokenType.STRING, strVal);
        }

        // identifier?
        if (Regex.IsMatch(Current.ToString(), "[A-Za-z_]"))
        {
            int startPos = _pos;
            while (_pos < _text.Length &&
                    Regex.IsMatch(_text[_pos].ToString(), "[A-Za-z0-9_]"))
            {
                _pos++;
            }
            string ident = _text.Substring(startPos, _pos - startPos);
            return new Token(TokenType.IDENT, ident);
        }

        // skip unrecognized
        _pos++;
        return NextToken();
    }
}
