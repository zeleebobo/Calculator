using System.Collections.Generic;
using Calculator.Parser;

namespace Calculator.Converter
{
    public interface INotationConverter
    {
        MathExpression Convert(MathExpression convertingExpression);
    }
}