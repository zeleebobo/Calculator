using System;

namespace Calculator.ExpressionElements.Constants
{
    [StringDefinition("PI")]
    public class PI : Number
    {
        public PI() : base(Math.PI)
        {
            
        }
    }
}