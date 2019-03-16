using System;
using System.Collections.Generic;
using System.Globalization;
using Calculator.Converter;
using Calculator.Evaluator;
using Calculator.ExpressionElements;
using Calculator.ExpressionElements.Functions;
using Calculator.ExpressionElements.Operators;
using Calculator.Parser;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(new StringParser(), 
                                            new InfixToPostfixConverter(), 
                                            new PostfixEvaluator());
            var inputLine = Console.ReadLine();
            var result = calculator.Calculate(inputLine);
            
            Console.WriteLine($"Result: {result.ToString(CultureInfo.InvariantCulture)}");
        }
    }
}