using System;
using Calculator.Converter;
using Calculator.Evaluator;
using Calculator.Parser;

namespace Calculator
{
    public class Calculator
    {
        private readonly ICalcParser parser;
        private readonly INotationConverter converter;
        private readonly IEvaluator evaluator;

        public Calculator(ICalcParser parser, INotationConverter converter, IEvaluator evaluator)
        {
            this.parser = parser;
            this.converter = converter;
            this.evaluator = evaluator;
        }
        
        public Calculator(ICalcParser parser, IEvaluator evaluator) : this(parser, null, evaluator)
        {
            
        }

        public double Calculate(string input)
        {
            var expression = parser.ParseElements(input);
            if (converter != null)
            {
                expression = converter.Convert(expression);
            }
            var result = evaluator.Evaluate(expression);
            return result.Value;
        }
    }
}