namespace Calculator.ExpressionElements
{
    [StringDefinition("(")]
    public class OpenBracket : ExpressionElement
    {
        public override void Validate(ExpressionElement previousElement, ExpressionElement nextElement)
        {
            
        }
    }
}