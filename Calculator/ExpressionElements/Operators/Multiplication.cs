using System.Transactions;

namespace Calculator.ExpressionElements.Operators
{
    public class Multiplication : Operator
    {
        public override int Priority => 2;
        public override Number Evaluate(Number firstOperand, Number secondOperand)
        {
            return new Number(firstOperand.Value * secondOperand.Value);
        }
    }
}