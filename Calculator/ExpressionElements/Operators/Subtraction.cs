namespace Calculator.ExpressionElements.Operators
{
    public class Subtraction : Operator
    {
        public override int Priority { get; }
        public override Number Evaluate(Number firstOperand, Number secondOperand)
        {
            return new Number(firstOperand.Value - secondOperand.Value);
        }
    }
}