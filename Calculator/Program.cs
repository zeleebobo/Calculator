using System;
using System.Globalization;
using Calculator.Converter;
using Calculator.Evaluator;
using Calculator.Parser;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(new StringParser(), new PostfixEvaluator(new InfixToPostfixConverter()));
            var inputLine = Console.ReadLine();
            var result = calculator.Calculate(inputLine);
            
            Console.WriteLine($"Result: {result.ToString(CultureInfo.InvariantCulture)}");
        }
    }
}