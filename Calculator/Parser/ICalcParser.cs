using System.Collections.Generic;

namespace Calculator.Parser
{
    public interface ICalcParser
    {
        IEnumerable<ExpressionElement> ParseElements(string input);
    }
}