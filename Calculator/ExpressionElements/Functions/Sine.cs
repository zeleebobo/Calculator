using System;

namespace Calculator.ExpressionElements.Functions
{
    [StringDefinition("Sin")]
    public class Sine : Function
    {
        public override Number Evaluate(Number parameter)
        {
            return new Number(Math.Sin(parameter.Value));
        }
    }
}