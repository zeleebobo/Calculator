using System.Collections.Generic;
using System.Data;
using Calculator.Converter;
using Calculator;
using Calculator.ExpressionElements;
using Calculator.ExpressionElements.Functions;
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
                new Subtraction(),
                new Number(3)
            };

            var expectedPostfixExpression = new MathExpression()
            {
                new Number(1),
                new Number(2),
                new Number(3),
                new Subtraction(),
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
                new Number(1),
                new Number(2),
                new Number(3),
                new Multiplication(),
                new Addition(),
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }

        [Fact]
        public void FullTest1()
        {
            var infixExpression = new MathExpression()
            {
                new Cosine(),
                new OpenBracket(),
                new Number(3),
                new Addition(),
                new Number(4), 
                new CloseBracket(),
                new Multiplication(),
                new Sine(),
                new OpenBracket(),
                new Number(8),
                new Division(),
                new Number(5),
                new CloseBracket(),
                new Subtraction(),
                new Number(4),
                new Multiplication(),
                new OpenBracket(),
                new Number(3),
                new Subtraction(),
                new Number(2),
                new CloseBracket()
            };

            var expectedPostfixExpression = new MathExpression()
            {
                new Number(3),
                new Number(4),
                new Addition(),
                new Cosine(),
                new Number(8),
                new Number(5),
                new Division(),
                new Sine(),
                new Multiplication(),
                new Number(4),
                new Number(3),
                new Number(2),
                new Subtraction(),
                new Multiplication(),
                new Subtraction()
            };

            var converter = new InfixToPostfixConverter();
            var actualPostfixExpression = converter.Convert(infixExpression);
            Assert.Equal(expectedPostfixExpression, actualPostfixExpression);
        }

        [Fact]
        void ValidationTest1()
        {
            var converter = new InfixToPostfixConverter();
            var expression = new MathExpression()
            {
                new Addition(), 
                new Number(2)
            };

            var ex = Assert.Throws<InvalidExpressionException>(() => converter.Convert(expression));
            
            Assert.Equal("Expression cannot starts with operator", ex.Message);
        }
    }
}