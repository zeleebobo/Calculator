using System.Collections.Generic;

namespace Calculator.Parser
{
    public interface ICalcParser
    {
        MathExpression ParseElements(string input);
    }
}