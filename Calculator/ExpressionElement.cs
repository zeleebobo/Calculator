using System;
using System.Runtime.InteropServices.ComTypes;

namespace Calculator
{
    public abstract class ExpressionElement
    {
        public abstract void Validate(ExpressionElement previousElement, ExpressionElement nextElement);
    }
}