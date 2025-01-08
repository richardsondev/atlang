public class Parser
{
    private readonly Lexer _lexer;
    private Token _current;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        _current = _lexer.NextToken();
    }

    private void Eat(TokenType type)
    {
        if (_current.Type == type)
            _current = _lexer.NextToken();
        else
            throw new Exception($"Expected {type}, got {_current.Type}");
    }

    public List<ASTNode> ParseProgram()
    {
        var stmts = new List<ASTNode>();
        while (_current.Type != TokenType.EOF)
        {
            var stmt = ParseStatement();
            if (stmt != null) stmts.Add(stmt);
        }
        return stmts;
    }

    private ASTNode? ParseStatement()
    {
        if (_current.Type == TokenType.AT)
        {
            Eat(TokenType.AT);
            if (_current.Type == TokenType.IDENT)
            {
                var varName = _current.Text;
                Eat(TokenType.IDENT);
                Eat(TokenType.EQUAL);
                if (_current.Type == TokenType.GETENV)
                {
                    Eat(TokenType.GETENV);
                    Eat(TokenType.LPAREN);
                    Eat(TokenType.AT);
                    var envName = _current.Text;
                    Eat(TokenType.IDENT);
                    Eat(TokenType.RPAREN);
                    return new EnvVarAssignment(varName, envName, null);
                }
                else if (_current.Type == TokenType.STRING)
                {
                    var s = _current.Text;
                    Eat(TokenType.STRING);
                    return new EnvVarAssignment(varName, null, s);
                }
                else if (_current.Type == TokenType.GETWEB)
                {
                    Eat(TokenType.GETWEB);
                    Eat(TokenType.LPAREN);
                    Eat(TokenType.AT);
                    var url = _current.Text;
                    Eat(TokenType.IDENT);
                    Eat(TokenType.RPAREN);
                    return new WebRequestAssign(varName, "GET", url, null, null);
                }
                else if (_current.Type == TokenType.POSTWEB)
                {
                    Eat(TokenType.POSTWEB);
                    Eat(TokenType.LPAREN);
                    Eat(TokenType.AT);
                    var url = _current.Text;
                    Eat(TokenType.IDENT);
                    Eat(TokenType.AT);
                    var postData = _current.Text;
                    Eat(TokenType.IDENT);
                    Eat(TokenType.RPAREN);
                    return new WebRequestAssign(varName, "POST", url, null, postData);
                }
                else
                {
                    throw new Exception("Invalid assignment");
                }
            }
            else if (_current.Type == TokenType.IF)
            {
                return ParseIfStatement();
            }
            else if (_current.Type == TokenType.PRINT)
            {
                return ParsePrintStatement();
            }
            else if (_current.Type == TokenType.STARTSERVER)
            {
                Eat(TokenType.STARTSERVER);
                Eat(TokenType.LPAREN);
                Eat(TokenType.AT);
                var folder = _current.Text;
                Eat(TokenType.IDENT);
                Eat(TokenType.AT);
                var port = _current.Text;
                Eat(TokenType.IDENT);
                Eat(TokenType.RPAREN);
                return new StartServerAssign(folder, port);
            }
            else
            {
                throw new Exception("Unexpected after '@'");
            }
        }
        else if (_current.Type == TokenType.IF)
        {
            return ParseIfStatement();
        }
        else if (_current.Type == TokenType.PRINT)
        {
            return ParsePrintStatement();
        }
        else if (_current.Type == TokenType.EOF)
        {
            return null;
        }
        else
        {
            throw new Exception($"Unexpected token {_current.Type} in statement");
        }
    }

    private ASTNode ParseIfStatement()
    {
        Eat(TokenType.IF);
        Eat(TokenType.LPAREN);
        var left = ParseExpression();
        if (_current.Type == TokenType.EQEQ) Eat(TokenType.EQEQ);
        else throw new Exception("Only == is supported.");
        var right = ParseExpression();
        Eat(TokenType.RPAREN);
        Eat(TokenType.LBRACE);
        var ifBody = new List<ASTNode>();
        while (_current.Type != TokenType.RBRACE && _current.Type != TokenType.EOF)
        {
            var s = ParseStatement();
            if (s != null) ifBody.Add(s);
        }
        Eat(TokenType.RBRACE);

        var elseBody = new List<ASTNode>();
        if (_current.Type == TokenType.ELSE)
        {
            Eat(TokenType.ELSE);
            Eat(TokenType.LBRACE);
            while (_current.Type != TokenType.RBRACE && _current.Type != TokenType.EOF)
            {
                var s = ParseStatement();
                if (s != null) elseBody.Add(s);
            }
            Eat(TokenType.RBRACE);
        }
        return new IfStatement(left, right, ifBody, elseBody);
    }

    private ASTNode ParsePrintStatement()
    {
        Eat(TokenType.PRINT);
        Eat(TokenType.LPAREN);
        var expr = ParseExpression();
        Eat(TokenType.RPAREN);
        return new PrintStatement(expr);
    }

    private ASTNode ParseExpression()
    {
        var left = ParseSimpleExpr();
        while (_current.Type == TokenType.PLUS)
        {
            var op = _current.Text;
            Eat(TokenType.PLUS);
            var right = ParseSimpleExpr();
            left = new BinaryExpression(left, op, right);
        }
        return left;
    }

    private ASTNode ParseSimpleExpr()
    {
        if (_current.Type == TokenType.AT)
        {
            Eat(TokenType.AT);
            var name = _current.Text;
            Eat(TokenType.IDENT);
            return new VarReference(name);
        }
        else if (_current.Type == TokenType.STRING)
        {
            var val = _current.Text;
            Eat(TokenType.STRING);
            return new StringLiteral(val);
        }
        else
        {
            throw new Exception($"Unexpected token {_current.Type} in expression");
        }
    }
}
