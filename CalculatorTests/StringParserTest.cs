using Xunit;
using Calculator;
using Calculator.ExpressionElements;
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
    }
}