using AtLangCompiler.Methods;
using System.Reflection;

namespace AtLangCompiler;

internal class Parser
{
    private readonly Lexer lexer;
    private readonly IReadOnlyDictionary<TokenType, IStatementParser> statementParsers;

    internal Token current;
    internal string varName = string.Empty;

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
        this.statementParsers = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.CustomAttributes.Any(e => e.AttributeType == typeof(ParserForAttribute)))
            .SelectMany(t => t.GetCustomAttributes<ParserForAttribute>().Select(attr => new
            {
                attr.TokenType,
                ParserType = t
            }))
            .ToDictionary(
                entry => entry.TokenType,
                entry => (IStatementParser)Activator.CreateInstance(entry.ParserType)!
            );

        this.current = this.lexer.NextToken();
    }

    internal void Eat(TokenType type)
    {
        if (current.Type == type)
        {
            current = lexer.NextToken();
        }
        else
        {
            throw new Exception($"Expected {type}, got {current.Type}");
        }
    }

    internal IList<ASTNode> ParseProgram()
    {
        IList<ASTNode> stmts = new List<ASTNode>();
        while (current.Type != TokenType.EOF)
        {
            ASTNode? stmt = ParseStatement();
            if (stmt != null) stmts.Add(stmt);
        }
        return stmts;
    }

    internal ASTNode? ParseStatement()
    {
        if (current.Type == TokenType.AT)
        {
            Eat(TokenType.AT);
            if (current.Type == TokenType.IDENT)
            {
                varName = current.Text;
                Eat(TokenType.IDENT);
                Eat(TokenType.EQUAL);

                if (statementParsers.TryGetValue(current.Type, out var statementParserIdent))
                {
                    return statementParserIdent.ParseStatement(this);
                }

                throw new Exception("Invalid assignment");
            }

            if (statementParsers.TryGetValue(current.Type, out var statementParserAt))
            {
                return statementParserAt.ParseStatement(this);
            }

            throw new Exception("Unexpected after '@'");
        }

        if (statementParsers.TryGetValue(current.Type, out var statementParser))
        {
            return statementParser.ParseStatement(this);
        }

        if (current.Type == TokenType.EOF)
        {
            return null;
        }
        else
        {
            throw new Exception($"Unexpected token {current.Type} in statement");
        }
    }

    internal ASTNode ParseExpression()
    {
        ASTNode left = ParseSimpleExpr();
        while (current.Type == TokenType.PLUS)
        {
            string op = current.Text;
            Eat(TokenType.PLUS);
            ASTNode right = ParseSimpleExpr();
            left = new BinaryExpression(left, op, right);
        }
        return left;
    }

    private ASTNode ParseSimpleExpr()
    {
        if (current.Type == TokenType.AT)
        {
            Eat(TokenType.AT);
            string name = current.Text;
            Eat(TokenType.IDENT);
            return new VarReference(name);
        }
        else if (current.Type == TokenType.STRING)
        {
            string val = current.Text;
            Eat(TokenType.STRING);
            return new StringLiteral(val);
        }
        else
        {
            throw new Exception($"Unexpected token {current.Type} in expression");
        }
    }
}
