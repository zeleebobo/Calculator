namespace Calculator.ExpressionElements
{
    public abstract class Function : ExpressionElement
    {
        public abstract Number Evaluate(Number parameter);
    }
}