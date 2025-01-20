using System.Reflection;
using System.Text.RegularExpressions;

namespace AtLangCompiler;

internal class Lexer
{
    private readonly string text;
    public IReadOnlyDictionary<string, TokenType> methodTokenTypeMap;

    private int pos = 0;

    public Lexer(string text)
    {
        this.text = text;
        this.methodTokenTypeMap = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ILexerTokenConfig).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .Select(configType => (ILexerTokenConfig)Activator.CreateInstance(configType)!)
            .SelectMany(config => config.TokenStrings)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    private char Current => pos < text.Length ? text[pos] : '\0';

    public Token NextToken()
    {
        // Skip whitespace
        while (pos < text.Length && char.IsWhiteSpace(Current))
        {
            pos++;
        }

        if (pos >= text.Length)
        {
            return new Token(TokenType.EOF, string.Empty);
        }

        string rest = text.Substring(pos);

        foreach (KeyValuePair<string, TokenType> methodToken in methodTokenTypeMap)
        {
            if (rest.StartsWith(methodToken.Key))
            {
                pos += methodToken.Key.Length;
                return new Token(methodToken.Value, methodToken.Key);
            }
        }

        // ==
        if (pos + 1 < text.Length && Current == '=' && text[pos + 1] == '=')
        {
            pos += 2;
            return new Token(TokenType.EQEQ, "==");
        }

        // single-char tokens
        switch (Current)
        {
            case '@':
                pos++;
                return new Token(TokenType.AT, "@");
            case '=':
                pos++;
                return new Token(TokenType.EQUAL, "=");
            case '+':
                pos++;
                return new Token(TokenType.PLUS, "+");
            case '(':
                pos++;
                return new Token(TokenType.LPAREN, "(");
            case ')':
                pos++;
                return new Token(TokenType.RPAREN, ")");
            case '{':
                pos++;
                return new Token(TokenType.LBRACE, "{");
            case '}':
                pos++;
                return new Token(TokenType.RBRACE, "}");
            case '"':
                pos++;
                int start = pos;
                while (pos < text.Length && text[pos] != '"') pos++;
                string strVal = text.Substring(start, pos - start);
                if (pos < text.Length) pos++; // skip closing quote
                return new Token(TokenType.STRING, strVal);
        }

        // identifier?
        if (Regex.IsMatch(Current.ToString(), "[A-Za-z_]"))
        {
            int startPos = pos;
            while (pos < text.Length &&
                    Regex.IsMatch(text[pos].ToString(), "[A-Za-z0-9_]"))
            {
                pos++;
            }
            string ident = text.Substring(startPos, pos - startPos);
            return new Token(TokenType.IDENT, ident);
        }

        // skip unrecognized
        pos++;
        return NextToken();
    }
}
