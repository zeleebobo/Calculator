using System;
using System.Collections.Generic;
using System.Data;
using Calculator.ExpressionElements;

namespace Calculator.Evaluator
{
    public class PostfixEvaluator : IEvaluator
    {
        public Number Evaluate(MathExpression expression)
        {
            if (expression.Count == 0)
                throw new InvalidExpressionException("Empty expression");
            
            var elementsStack = new Stack<Number>();

            foreach (var expressionElement in expression)
            {
                if (expressionElement is Number number)
                {
                    elementsStack.Push(number);
                }
                else if (expressionElement is Operator expressionOperator)
                {
                    var operand2 = elementsStack.Pop();
                    var operand1 = elementsStack.Pop();
                    elementsStack.Push(expressionOperator.Evaluate(operand1, operand2));
                }
                else if (expressionElement is Function expressionFunction)
                {
                    var parameter = elementsStack.Pop();
                    elementsStack.Push(expressionFunction.Evaluate(parameter));
                }
                else
                {
                    throw new EvaluateException($"Unsupported element \"{expressionElement.GetType()}\" in postfix expression");
                }
            }
            
            return elementsStack.Pop() as Number;
        }
    }
}