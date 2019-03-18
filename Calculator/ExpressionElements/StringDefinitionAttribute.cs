using System;

namespace Calculator.ExpressionElements
{
    public class StringDefinitionAttribute : Attribute
    {
        public StringDefinitionAttribute(string value)
        {
            Value = value;
        }
        
        public string Value { get; }
    }
}