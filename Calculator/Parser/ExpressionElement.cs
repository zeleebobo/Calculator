using System;
using System.Runtime.InteropServices.ComTypes;

namespace Calculator.Parser
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
    }
}