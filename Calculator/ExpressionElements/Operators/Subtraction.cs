namespace Calculator.ExpressionElements.Operators
{
    [StringDefinition("-")]
    public class Subtraction : Operator
    {
        public override int Priority => 3;
        public override Number Evaluate(Number firstOperand, Number secondOperand)
        {
            return new Number(firstOperand.Value - secondOperand.Value);
        }
    }
}