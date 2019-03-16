using System;

namespace Calculator.ExpressionElements.Functions
{
    public class Sine : Function
    {
        public override Number Evaluate(Number parameter)
        {
            return new Number(Math.Sin(parameter.Value));
        }
    }
}