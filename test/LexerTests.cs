using System.Reflection;

namespace AtLangCompiler.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        [Description("Test for empty input string")]
        public void NextToken_EmptyString_ReturnsEOF()
        {
            var lexer = new Lexer("");
            var token = lexer.NextToken();
            Assert.AreEqual(TokenType.EOF, token.Type);
        }

        [TestMethod]
        [Description("Test for whitespace-only input")]
        public void NextToken_WhitespaceOnly_ReturnsEOF()
        {
            var lexer = new Lexer("    \t\n");
            var token = lexer.NextToken();
            Assert.AreEqual(TokenType.EOF, token.Type);
        }

        [TestMethod]
        [DataRow("@if", TokenType.IF, "@if")]
        [DataRow("@else", TokenType.ELSE, "@else")]
        [DataRow("@print", TokenType.PRINT, "@print")]
        [Description("Test for keywords starting with @")]
        public void NextToken_Keywords_ReturnsExpectedToken(string input, TokenType expectedType, string expectedValue)
        {
            var lexer = new Lexer(input);
            var token = lexer.NextToken();
            Assert.AreEqual(expectedType, token.Type);
            Assert.AreEqual(expectedValue, token.Text);
        }

        [TestMethod]
        [DataRow("==", TokenType.EQEQ, "==")]
        [Description("Test for comparison operator ==")]
        public void NextToken_ComparisonOperator_ReturnsExpectedToken(string input, TokenType expectedType, string expectedValue)
        {
            var lexer = new Lexer(input);
            var token = lexer.NextToken();
            Assert.AreEqual(expectedType, token.Type);
            Assert.AreEqual(expectedValue, token.Text);
        }

        [TestMethod]
        [DataRow("+", TokenType.PLUS, "+")]
        [DataRow("=", TokenType.EQUAL, "=")]
        [DataRow("@", TokenType.AT, "@")]
        [DataRow("(", TokenType.LPAREN, "(")]
        [DataRow(")", TokenType.RPAREN, ")")]
        [DataRow("{", TokenType.LBRACE, "{")]
        [DataRow("}", TokenType.RBRACE, "}")]
        [Description("Test for single-character tokens")]
        public void NextToken_SingleCharTokens_ReturnsExpectedToken(string input, TokenType expectedType, string expectedValue)
        {
            var lexer = new Lexer(input);
            var token = lexer.NextToken();
            Assert.AreEqual(expectedType, token.Type);
            Assert.AreEqual(expectedValue, token.Text);
        }

        [TestMethod]
        [Description("Test for string literals")]
        public void NextToken_StringLiteral_ReturnsExpectedToken()
        {
            var lexer = new Lexer("\"hello world\"");
            var token = lexer.NextToken();
            Assert.AreEqual(TokenType.STRING, token.Type);
            Assert.AreEqual("hello world", token.Text);
        }

        [TestMethod]
        [DataRow("identifier", "identifier")]
        [DataRow("_id123", "_id123")]
        [Description("Test for identifiers")]
        public void NextToken_Identifier_ReturnsExpectedToken(string input, string expectedValue)
        {
            var lexer = new Lexer(input);
            var token = lexer.NextToken();
            Assert.AreEqual(TokenType.IDENT, token.Type);
            Assert.AreEqual(expectedValue, token.Text);
        }

        [TestMethod]
        [Description("Test for unrecognized characters")]
        public void NextToken_UnrecognizedCharacter_SkipsAndContinues()
        {
            var lexer = new Lexer("#");
            var token = lexer.NextToken();
            Assert.AreEqual(TokenType.EOF, token.Type); // Should skip unknown and reach EOF
        }

        [TestMethod]
        [Description("Test for mixed content")]
        public void NextToken_MixedContent_ReturnsTokensInSequence()
        {
            var lexer = new Lexer("@if + @else");
            var token1 = lexer.NextToken();
            Assert.AreEqual(TokenType.IF, token1.Type);

            var token2 = lexer.NextToken();
            Assert.AreEqual(TokenType.PLUS, token2.Type);

            var token3 = lexer.NextToken();
            Assert.AreEqual(TokenType.ELSE, token3.Type);

            var token4 = lexer.NextToken();
            Assert.AreEqual(TokenType.EOF, token4.Type);
        }

        [TestMethod]
        [Description("Test for token mappings from ILexerTokenConfig implementation")]
        [DynamicData(nameof(GetMethodTokenData), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(DisplayTokenData))]
        public void NextToken_CustomMappings_ReturnsExpectedTokens(string tokenString, TokenType expectedType)
        {
            var lexer = new Lexer(tokenString);
            var token = lexer.NextToken();
            Assert.AreEqual(expectedType, token.Type);
            Assert.AreEqual(tokenString, token.Text);
        }

        public static IEnumerable<object[]> GetMethodTokenData()
        {
            var methodTokenTypeMap = Assembly.GetAssembly(typeof(Compiler))!
                .GetTypes()
                .Where(t => typeof(ILexerTokenConfig).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Select(configType => (ILexerTokenConfig)Activator.CreateInstance(configType)!)
                .SelectMany(config => config.TokenStrings)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var methodToken in methodTokenTypeMap)
            {
                yield return new object[] { methodToken.Key, methodToken.Value };
            }
        }

        public static string DisplayTokenData(MethodInfo methodInfo, object[] data)
        {
            return data.Length > 1 ? $"{data[0]} ({data[1]})" : string.Join(", ", data);
        }
    }
}
