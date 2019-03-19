using System.Data;

namespace Calculator.ExpressionElements
{
    public abstract class Operator : ExpressionElement
    {
        public abstract int Priority { get; }
        public abstract Number Evaluate(Number firstOperand, Number secondOperand);

        public override void Validate(ExpressionElement previousElement, ExpressionElement nextElement)
        {
            if (!(previousElement is CloseBracket || previousElement is Number))
                throw new InvalidExpressionException("Operator must be placed only after number or closet bracket");
            
            if (!(nextElement is Number || nextElement is OpenBracket || nextElement is Function))
                throw new InvalidExpressionException("Operator must be placed only before number, function or opening bracket");
        }
    }
}