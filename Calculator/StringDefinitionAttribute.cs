using System;

namespace Calculator
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