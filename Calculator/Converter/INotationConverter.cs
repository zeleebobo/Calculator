using System.Collections.Generic;
using Calculator.Parser;

namespace Calculator.Converter
{
    public interface INotationConverter
    {
        IEnumerable<ExpressionElement> Convert(IEnumerable<ExpressionElement> expressionElements);
    }
}