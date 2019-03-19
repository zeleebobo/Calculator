using System;
using System.Data;
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

        public CalculationResult Calculate(string input)
        {
            CalculationResult calculationResult;
            try
            {
                var expression = parser.ParseElements(input);
                if (converter != null)
                {
                    expression = converter.Convert(expression);
                }

                var evaluationResult = evaluator.Evaluate(expression);

                calculationResult = new CalculationResult(evaluationResult.Value);
            }
            catch (InvalidExpressionException e)
            {
                calculationResult = new CalculationResult(e);
            }
            catch (FormatException e)
            {
                calculationResult = new CalculationResult(e);
            }
            
            
            return calculationResult;
        }
    }
}