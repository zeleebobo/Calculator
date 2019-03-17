using System;
using System.Transactions;

namespace Calculator.ExpressionElements.Operators
{
    [StringDefinition("+")]
    public class Addition : Operator
    {
        public override int Priority => 2;
        public override Number Evaluate(Number firstOperand, Number secondOperand)
        {
            var result = firstOperand.Value + secondOperand.Value;
            return new Number(result);
        }
    }
}