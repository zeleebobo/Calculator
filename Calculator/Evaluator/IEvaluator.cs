using System.Collections.Generic;
using Calculator.Parser;

namespace Calculator.Evaluator
{
    public interface IEvaluator
    {
        double Evaluate(IEnumerable<ExpressionElement> expressionElements);
    }
}