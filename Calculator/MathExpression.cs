using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Calculator.ExpressionElements;

namespace Calculator
{
    public class MathExpression : List<ExpressionElement>
    {
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
                
            foreach (var expressionElement in this)
            {
                if (expressionElement is Number number)
                {
                    stringBuilder.Append(number.Value);
                }
                else
                {
                    var stringDefinitionAttribute =
                        expressionElement.GetType().GetCustomAttribute<StringDefinitionAttribute>();
                    if (stringDefinitionAttribute != null)
                    {
                        stringBuilder.Append(stringDefinitionAttribute.Value);
                    }
                    else
                    {
                        throw new CustomAttributeFormatException("Some of expression elements hasn't string definition attribute");
                    }
                }
                stringBuilder.Append(" ");
            }
            return stringBuilder.ToString();
        }
    }
}