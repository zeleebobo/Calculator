using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Calculator.ExpressionElements;

namespace Calculator.Parser
{
    public class StringParser : ICalcParser
    {
        private static Dictionary<string, Type> definedElements;
        static StringParser()
        {
            definedElements = GetStringDefinitionsOfElements();
        }
        public MathExpression ParseElements(string input)
        {
            var expression = new MathExpression();
            foreach (var stringElement in input.Split(' '))
            {
                var lowerElement = stringElement.ToLower();
                var isNumber = double.TryParse(stringElement, NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture, out var number);
                if (isNumber)
                {
                    expression.Add(new Number(number));
                }
                else if (definedElements.ContainsKey(lowerElement))
                {
                    var elementType = definedElements[lowerElement];
                    var elementInstance = (ExpressionElement) Activator.CreateInstance(elementType);
                    expression.Add(elementInstance);
                }
                else
                {
                    throw new FormatException("String definition of element not found in registered elements");
                }
            }

            return expression;
        }

        private static Dictionary<string, Type> GetStringDefinitionsOfElements()
        {
            var definitions = new Dictionary<string, Type>();
            var subclassTypes = Assembly
                .GetAssembly(typeof(ExpressionElement))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ExpressionElement)) && 
                            (Attribute.GetCustomAttribute(t, typeof(StringDefinitionAttribute)) != null));

            foreach (var subclassType in subclassTypes)
            {
                var stringDefinition = subclassType.GetCustomAttribute<StringDefinitionAttribute>().Value;
                var lowerDefinition = stringDefinition.ToLower();
                if (definitions.ContainsKey(lowerDefinition))
                {
                    throw new CustomAttributeFormatException("String definition collision. " +
                                                             "Some of elements has a same StringDefinitionAttribute value.");
                }
                definitions[lowerDefinition] = subclassType;
            }
            
            return definitions;
        }
    }
}