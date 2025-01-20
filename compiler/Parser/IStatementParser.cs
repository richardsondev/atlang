namespace AtLangCompiler;

internal interface IStatementParser
{
    ASTNode ParseStatement(Parser parser);
}
