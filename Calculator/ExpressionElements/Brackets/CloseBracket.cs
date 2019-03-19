namespace Calculator.ExpressionElements
{
    [StringDefinition(")")]
    public class CloseBracket : ExpressionElement
    {
        public override void Validate(ExpressionElement previousElement, ExpressionElement nextElement)
        {
            
        }
    }
}