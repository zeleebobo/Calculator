using System.Collections.Generic;
using Calculator.Converter;
using Calculator;
using Calculator.ExpressionElements;
using Calculator.ExpressionElements.Operators;
using Xunit;

namespace CalculatorTests
{
    public class InfixToPostfixConverterTest
    {
        [Fact]
        public void SimpleConvertTest1()
        {
            var infixExpression = new MathExpression()
            {
                new Number(1),
                new Addition(),
                new Number(1)
            };

            var expectedPostfixExpression = new MathExpression()
            {
                new Number(1),
                new Number(1),
                new Addition()
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }
        
        [Fact]
        public void SimpleConvertTest2()
        {
            var infixExpression = new MathExpression()
            {
                new Number(1),
                new Addition(),
                new Number(2), 
                new Addition(),
                new Number(3)
            };

            var expectedPostfixExpression = new MathExpression()
            {
                new Number(1),
                new Number(2),
                new Addition(),
                new Number(3),
                new Addition()
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }
        
        [Fact]
        public void PriorityTest1()
        {
            var infixExpression = new MathExpression()
            {
                new Number(1),
                new Addition(),
                new Number(2), 
                new Multiplication(),
                new Number(3)
            };

            var expectedPostfixExpression = new MathExpression()
            {
                new Number(2),
                new Number(3),
                new Multiplication(),
                new Number(1),
                new Addition(),
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }
    }
}