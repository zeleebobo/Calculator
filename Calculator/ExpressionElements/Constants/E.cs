using System;

namespace Calculator.ExpressionElements.Constants
{
    [StringDefinition("E")]
    public class E : Number
    {
        public E() : base(Math.E)
        {
        }
    }
}