namespace AtLangCompiler.Methods
{
    [ParserFor(TokenType.STRING)]
    internal class StringParser : IStatementParser
    {
        public ASTNode ParseStatement(Parser parser)
        {
            var s = parser.current.Text;
            parser.Eat(TokenType.STRING);
            return new EnvVarAssignment(parser.varName, null, s);
        }
    }
}
