using Xunit;
using Calculator;
using Calculator.Parser;

namespace CalculatorTests
{
    public class StringParserTest
    {
        [Fact]
        public void SimpleParsing1()
        {
            var inputString = "1 + 2";
            var expectedExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "2")
            };

            var parser = new StringParser();
            var actualExpression = parser.ParseElements(inputString);
            Assert.Equal(expectedExpression, actualExpression);
        }
        
        [Fact]
        public void SimpleParsing2()
        {
            var inputString = "1 + 2 + 3";
            var expectedExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "2"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "3")
            };
            
            var parser = new StringParser();
            var actualExpression = parser.ParseElements(inputString);
            Assert.Equal(expectedExpression, actualExpression);
        }
    }
}