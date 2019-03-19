using System;
using System.Globalization;

namespace Calculator
{
    public class CalculationResult
    {
        private Exception exception;
        public CalculationResult(Exception exception)
        {
            this.exception = exception;
            IsError = true;
            ErrorMessage = exception.Message;
            Value = double.NaN;
        }

        public CalculationResult(double value)
        {
            Value = value;
            IsError = false;
            ErrorMessage = null;
        }
        
        public bool IsError { get; }
        public string ErrorMessage { get; }
        public double Value { get; }
        
        public override string ToString()
        {
            return IsError ? $"Error: {exception.GetType().Name}: {ErrorMessage}" : 
                             $"Result: {Value.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}