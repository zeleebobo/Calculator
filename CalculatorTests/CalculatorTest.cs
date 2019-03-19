using System;
using Xunit;
using Calculator;
using Calculator.Converter;
using Calculator.Evaluator;
using Calculator.Parser;

namespace CalculatorTests
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData("1 + 1", 2)]
        [InlineData("0 + 3", 3)]
        [InlineData("0 - 4", -4)]
        [InlineData("PI + 0", Math.PI)]
        [InlineData("cos ( 0 )", 1)]
        public void SuccessCalculates(string input, double expected)
        {
            var calc = new Calculator.Calculator(new StringParser(), 
                                                 new InfixToPostfixConverter(),
                                                 new PostfixEvaluator());
            var result = calc.Calculate(input).Value;
            
            Assert.Equal(expected, result, 5);
        }
    }
}