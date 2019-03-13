using System.Collections.Generic;
using Calculator.Converter;
using Calculator;
using Xunit;

namespace CalculatorTests
{
    public class InfixToPostfixConverterTest
    {
        [Fact]
        public void SimpleConvertTest1()
        {
            var infixExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "1")
            };

            var expectedPostfixExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Operator, "+")
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }
        
        [Fact]
        public void SimpleConvertTest2()
        {
            var infixExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "2"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "3")
            };

            var expectedPostfixExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Number, "2"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "3"),
                new ExpressionElement(ElementType.Operator, "+")
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }
        
        [Fact]
        public void PriorityTest1()
        {
            var infixExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Operator, "+"),
                new ExpressionElement(ElementType.Number, "2"),
                new ExpressionElement(ElementType.Operator, "*"),
                new ExpressionElement(ElementType.Number, "3")
            };

            var expectedPostfixExpression = new[]
            {
                new ExpressionElement(ElementType.Number, "2"),
                new ExpressionElement(ElementType.Number, "3"),
                new ExpressionElement(ElementType.Operator, "*"),
                new ExpressionElement(ElementType.Number, "1"),
                new ExpressionElement(ElementType.Operator, "+")
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }
    }
}