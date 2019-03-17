namespace Calculator.ExpressionElements
{
    public class Number : ExpressionElement
    {
        public Number(double value) : base()
        {
            Value = value;
        }
        
        public double Value { get; }

        public override bool Equals(object obj)
        {
            var number = obj as Number;
            if (number == null)
            {
                return false;
            }
            
            return Value.Equals(number.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}