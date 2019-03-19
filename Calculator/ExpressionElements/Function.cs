using System.Data;

namespace Calculator.ExpressionElements
{
    public abstract class Function : ExpressionElement
    {
        public abstract Number Evaluate(Number parameter);

        public override void Validate(ExpressionElement previousElement, ExpressionElement nextElement)
        {
            if (!(previousElement is Operator || previousElement is Function || previousElement is OpenBracket))
                throw new InvalidExpressionException("Function must be placed only after operator, opening bracket or another function");
            if (!(nextElement is Number || nextElement is OpenBracket))
                throw new InvalidExpressionException("Function must be placed before number or opening bracket");
        }
    }
}