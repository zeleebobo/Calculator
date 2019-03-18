using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Calculator.ExpressionElements;

namespace Calculator
{
    public class MathExpression : List<ExpressionElement>, IEquatable<MathExpression>
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MathExpression) obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

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

        public bool Equals(MathExpression other)
        {
            if (other.Count != Count)
            {
                return false;
            }

            for (var i = 0; i < Count; i++)
            {
                var element1 = this[i];
                var element2 = other[i];

                if (element1.GetType() != element2.GetType())
                {
                    return false;
                }

                if (!(element1 is Number number1)) continue;
                if (!number1.Value.Equals(((Number) element2).Value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}