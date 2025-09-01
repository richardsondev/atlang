namespace AtLangCompiler.Methods
{
    [ParserFor(TokenType.STRING)]
    internal class StringParser : IStatementParser
    {
        public ASTNode ParseStatement(Parser parser)
        {
            var s = parser.current.Text;
            parser.Eat(TokenType.STRING);

            if (!string.IsNullOrEmpty(parser.varName))
            {
                return new VarAssignment(parser.varName, s);
            }

            return new StringLiteral(s);
        }
    }
}
