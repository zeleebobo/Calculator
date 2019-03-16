using System.Transactions;

namespace Calculator.ExpressionElements.Operators
{
    public class Addition : Operator
    {
        public override int Priority => 3;
        public override Number Evaluate(Number firstOperand, Number secondOperand)
        {
            return new Number(firstOperand.Value + secondOperand.Value);
        }
    }
}