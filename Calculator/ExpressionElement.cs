using System;
using System.Runtime.InteropServices.ComTypes;

namespace Calculator
{
    public abstract class ExpressionElement
    {
        public override bool Equals(object obj)
        {
            return GetType() == obj.GetType();
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }
    }
}