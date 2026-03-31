namespace AtLangCompiler.Methods
{
    [ParserFor(TokenType.NUMBER)]
    internal class NumberParser : IStatementParser
    {
        public ASTNode ParseStatement(Parser parser)
        {
            var n = parser.current.Number;
            parser.Eat(TokenType.NUMBER);

            if (!string.IsNullOrEmpty(parser.varName))
            {
                return new VarAssignment(parser.varName, n);
            }

            return new NumberLiteral(n);
        }
    }
}
