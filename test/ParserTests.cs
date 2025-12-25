using AtLangCompiler.Methods;
using System.Reflection;

namespace AtLangCompiler.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        [Description("Test initialization of the parser")]
        public void Parser_Initialization_SetsCurrentToken()
        {
            var lexer = new Lexer("@if");
            var parser = new Parser(lexer);

            Assert.AreEqual(TokenType.IF, parser.current.Type);
        }

        [TestMethod]
        [Description("Test dynamic statement parsing from ParserFor attributes")]
        [DynamicData(nameof(GetParserStatementData), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(DisplayParserData))]
        public void ParseStatement_ValidToken_ReturnsExpectedStatement(TokenType tokenType,
            Type parserType,
            string tokenStatement)
        {
            var lexer = new Lexer(tokenStatement);
            var parser = new Parser(lexer);

            ASTNode? result = parser.ParseStatement();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ASTNode));
        }

        [TestMethod]
        [Description("Test ParseProgram handles multiple statements")]
        public void ParseProgram_MultipleStatements_ReturnsAllStatements()
        {
            var lexer = new Lexer(@"
                @NAME = @getEnv(@USERNAME)
                @GREETING = ""Hello, ""
                @print(@GREETING + @NAME)");

            var parser = new Parser(lexer);

            var program = parser.ParseProgram();
            Assert.AreEqual(3, program.Count);
            Assert.AreEqual(typeof(EnvVarAssignment), program[0].GetType());
            Assert.AreEqual(typeof(VarAssignment), program[1].GetType());
            Assert.AreEqual(typeof(PrintStatement), program[2].GetType());
        }

        [TestMethod]
        [Description("Test ParseExpression handles binary expressions")]
        public void ParseExpression_BinaryExpression_ReturnsBinaryExpressionNode()
        {
            var lexer = new Lexer("@var1 + \"string\"");
            var parser = new Parser(lexer);

            var expression = parser.ParseExpression();
            Assert.IsInstanceOfType(expression, typeof(BinaryExpression));
        }

        [TestMethod]
        [Description("Test Eat method advances token correctly")]
        public void Eat_CorrectToken_AdvancesCurrentToken()
        {
            var lexer = new Lexer("@if +");
            var parser = new Parser(lexer);

            parser.Eat(TokenType.IF);
            Assert.AreEqual(TokenType.PLUS, parser.current.Type);
        }

        [TestMethod]
        [Description("Test Eat throws exception for incorrect token")]
        [ExpectedException(typeof(Exception))]
        public void Eat_IncorrectToken_ThrowsException()
        {
            var lexer = new Lexer("@else");
            var parser = new Parser(lexer);

            parser.Eat(TokenType.IF); // Mismatched token type
        }

        [TestMethod]
        [Description("Test ParseSimpleExpr handles variable references")]
        public void ParseSimpleExpr_VariableReference_ReturnsVarReferenceNode()
        {
            var lexer = new Lexer("@varName");
            var parser = new Parser(lexer);

            var result = parser.ParseExpression();
            Assert.IsInstanceOfType(result, typeof(VarReference));
        }

        [TestMethod]
        [Description("Test ParseSimpleExpr handles string literals")]
        public void ParseSimpleExpr_StringLiteral_ReturnsStringLiteralNode()
        {
            var lexer = new Lexer("\"test\"");
            var parser = new Parser(lexer);

            var result = parser.ParseExpression();
            Assert.IsInstanceOfType(result, typeof(StringLiteral));
        }

        [TestMethod]
        [Description("Test ParseSimpleExpr handles number literals")]
        public void ParseSimpleExpr_NumberLiteral_ReturnsNumberLiteralNode()
        {
            var lexer = new Lexer("123");
            var parser = new Parser(lexer);

            var result = parser.ParseExpression();
            Assert.IsInstanceOfType(result, typeof(NumberLiteral));
        }

        public static IEnumerable<object[]> GetParserStatementData()
        {
            var statementParsers = Assembly.GetAssembly(typeof(Compiler))!
                .GetTypes()
                .Where(t => t.CustomAttributes.Any(attr => attr.AttributeType == typeof(ParserForAttribute)))
                .SelectMany(t => t.GetCustomAttributes<ParserForAttribute>().Select(attr => new
                {
                    attr.TokenType,
                    ParserType = t,
                    attr.InputTokens,
                    attr.InputSeparator,
                    attr.HasBody,
                    attr.PrerequisiteToken
                }));

            var methodTokenTypeMap = Assembly.GetAssembly(typeof(Compiler))!
                .GetTypes()
                .Where(t => typeof(ILexerTokenConfig).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Select(configType => (ILexerTokenConfig)Activator.CreateInstance(configType)!)
                .SelectMany(config => config.TokenStrings)
                .ToDictionary(pair => pair.Value, pair => pair.Key);

            foreach (var parser in statementParsers)
            {
                string statement = string.Empty;

                if (parser.PrerequisiteToken != null && methodTokenTypeMap.TryGetValue(parser.PrerequisiteToken.Value, out var preReqType))
                {
                    var preReqParser = statementParsers.First(q => q.TokenType == parser.PrerequisiteToken);
                    statement += CreateTokenStatement(preReqType!, preReqParser.InputTokens, preReqParser.InputSeparator, preReqParser.HasBody);
                }

                if (methodTokenTypeMap.TryGetValue(parser.TokenType, out var type))
                {
                    statement += CreateTokenStatement(type!, parser.InputTokens, parser.InputSeparator, parser.HasBody);
                }

                if (!string.IsNullOrWhiteSpace(statement))
                {
                    yield return new object[]
                    {
                        parser.TokenType,
                        parser.ParserType,
                        statement
                    };
                }
            }
        }

        public static string DisplayParserData(MethodInfo methodInfo, object[] data)
        {
            return data.Length > 1 ? $"{data[0]} ({(data[1] as Type)!.Name})" : string.Join(", ", data);
        }

        private static string CreateTokenStatement(string tokenStatement, short inputTokens, string inputSeparator, bool hasBody)
        {
            var statement = tokenStatement;

            if (inputTokens > 0)
            {
                statement += "(";

                List<string> statementInputTokens = [];
                for (int i = 0; i < inputTokens; i++)
                {
                    statementInputTokens.Add($"@INPUT{i}");
                }
                statement += string.Join(inputSeparator, statementInputTokens);

                statement += ")";
            }

            if (hasBody)
            {
                statement += "{}";
            }

            return statement;
        }
    }
}
