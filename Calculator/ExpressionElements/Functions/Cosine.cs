using System;

namespace Calculator.ExpressionElements.Functions
{
    public class Cosine : Function
    {
        public override Number Evaluate(Number argument)
        {
            return new Number(Math.Cos(argument.Value));
        }
    }
}