using Xunit;
using Calculator;
using Calculator.ExpressionElements;
using Calculator.ExpressionElements.Constants;
using Calculator.ExpressionElements.Functions;
using Calculator.ExpressionElements.Operators;
using Calculator.Parser;

namespace CalculatorTests
{
    public class StringParserTest
    {
        [Fact]
        public void SimpleParsing1()
        {
            var inputString = "1 + 2";
            var expectedExpression = new MathExpression()
            {
                new Number(1),
                new Addition(),
                new Number(2)
            };

            var parser = new StringParser();
            var actualExpression = parser.ParseElements(inputString);
            Assert.Equal(expectedExpression, actualExpression);
        }
        
        [Fact]
        public void SimpleParsing2()
        {
            var inputString = "1 + 2 + 3";
            var expectedExpression = new MathExpression()
            {
                new Number(1),
                new Addition(),
                new Number(2),
                new Addition(),
                new Number(3)
            };
            
            var parser = new StringParser();
            var actualExpression = parser.ParseElements(inputString);
            Assert.Equal(expectedExpression, actualExpression);
        }

        [Fact]
        public void ParsingWithFunction1()
        {
            var inputString = "1 + cos ( 1 + 3 )";
            var expectedExpression = new MathExpression()
            {
                new Number(1),
                new Addition(),
                new Cosine(),
                new OpenBracket(),
                new Number(1),
                new Addition(),
                new Number(3),
                new CloseBracket()
            };
            
            var parser = new StringParser();
            var actualExpression = parser.ParseElements(inputString);
            Assert.Equal(expectedExpression, actualExpression);
        }

        [Fact]
        public void ParsingWithConstant1()
        {
            var inputString = "PI + e + 3";
            var expectedExpression = new MathExpression()
            {
                new PI(),
                new Addition(),
                new E(),
                new Addition(),
                new Number(3)
            };
            
            var parser = new StringParser();
            var actualExpression = parser.ParseElements(inputString);
            Assert.Equal(expectedExpression, actualExpression);
        }
    }
}