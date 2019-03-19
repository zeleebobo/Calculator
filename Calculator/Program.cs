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
            Console.WriteLine("To exit press Ctrl + C");
            while (true)
            {
                Console.Write("Expression: ");
                var inputLine = Console.ReadLine();
                var result = calculator.Calculate(inputLine);
            
                Console.WriteLine($"{result}\n");
            }
        }
    }
}