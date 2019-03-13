using System;
using Calculator.Evaluator;
using Calculator.Parser;

namespace Calculator
{
    public class Calculator
    {
        private readonly ICalcParser parser;
        private readonly IEvaluator evaluator;

        public Calculator() : this(new StringParser(), new PostfixEvaluator())
        {
            
        }
        
        public Calculator(ICalcParser parser, IEvaluator evaluator)
        {
            this.parser = parser;
            this.evaluator = evaluator;
        }

        public double Calculate(string input)
        {
            var expression = parser.ParseElements(input);
            var result = evaluator.Evaluate(expression);
            return result;
        }
    }
}