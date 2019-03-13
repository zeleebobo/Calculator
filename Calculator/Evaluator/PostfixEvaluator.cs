using System.Collections.Generic;
using Calculator.Converter;
using Calculator.Parser;

namespace Calculator.Evaluator
{
    public class PostfixEvaluator : IEvaluator
    {
        private readonly INotationConverter notationConverter;
        
        public PostfixEvaluator(INotationConverter notationConverter)
        {
            this.notationConverter = notationConverter;
        }
        
        public double Evaluate(IEnumerable<ExpressionElement> expressionElements)
        {
            var postfixExpression = notationConverter.Convert(expressionElements);
            
            throw new System.NotImplementedException();
        }
    }
}