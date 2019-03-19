using System.Data;

namespace Calculator.ExpressionElements
{
    public class Number : ExpressionElement
    {
        public Number(double value) : base()
        {
            Value = value;
        }
        
        public double Value { get; }
        public override void Validate(ExpressionElement previousElement, ExpressionElement nextElement)
        {
            if (previousElement is Number || nextElement is Number)
                throw new InvalidExpressionException("Numbers cannot be placed one after another");
            
            if (previousElement is Function || nextElement is Function)
                throw new InvalidExpressionException("Function cannot be placed before or after number element");
            
            if (previousElement is CloseBracket || nextElement is OpenBracket)
                throw new InvalidExpressionException("Number cannot be placed before opening bracket or after closing bracket");
        }
    }
}