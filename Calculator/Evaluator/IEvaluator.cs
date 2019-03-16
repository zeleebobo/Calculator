using System.Collections.Generic;
using Calculator.ExpressionElements;

namespace Calculator.Evaluator
{
    public interface IEvaluator
    {
        Number Evaluate(MathExpression expression);
    }
}