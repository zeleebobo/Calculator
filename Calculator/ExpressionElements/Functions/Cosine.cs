using System;

namespace Calculator.ExpressionElements.Functions
{
    [StringDefinition("Cos")]
    public class Cosine : Function
    {
        public override Number Evaluate(Number parameter)
        {
            return new Number(Math.Cos(parameter.Value));
        }
    }
}