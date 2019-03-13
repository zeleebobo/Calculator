using System;
using System.Runtime.InteropServices.ComTypes;

namespace Calculator
{
    public enum ElementType
    {
        Number,
        Operator,
        Function,
        OpenBracket,
        CloseBracket
    }
    
    public class ExpressionElement
    {
        public ExpressionElement(ElementType type, string value)
        {
            Type = type;
            Value = value;
        }

        public ElementType Type { get; }

        public string Value { get; }

        public override bool Equals(object obj)
        {
            var item = obj as ExpressionElement;
            if (item == null)
            {
                return false;
            }

            return Type.Equals(item.Type) && Value.Equals(item.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}