namespace Calculator.ExpressionElements
{
    public class Number : ExpressionElement
    {
        public Number(double value) : base()
        {
            Value = value;
        }
        
        public double Value { get; }
    }
}