using System;
using System.Data;

namespace Calculator.ExpressionElements.Operators
{
    [StringDefinition("/")]
    public class Division : Operator
    {
        public override int Priority => 3;
        public override Number Evaluate(Number firstOperand, Number secondOperand)
        {
            if (Math.Abs(secondOperand.Value) < 0.00000000000001)
                throw new EvaluateException("Division by zero");
            return new Number(firstOperand.Value / secondOperand.Value);
        }
    }
}