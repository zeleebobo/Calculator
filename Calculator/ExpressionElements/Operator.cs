namespace Calculator.ExpressionElements
{
    public abstract class Operator : ExpressionElement
    {
        public abstract int Priority { get; }
        public abstract Number Evaluate(Number firstOperand, Number secondOperand);
    }
}