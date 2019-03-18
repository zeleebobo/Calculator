using System;
using System.Collections.Generic;
using Calculator.ExpressionElements;

namespace Calculator.Converter
{
    public class InfixToPostfixConverter : INotationConverter
    {
        public MathExpression Convert(MathExpression convertingExpression)
        {
            var postfixExpression = new MathExpression();
            var bufferStack = new Stack<ExpressionElement>();
            
            foreach (var expressionElement in convertingExpression)
            {
                switch (expressionElement)
                {
                    case Number number:
                        postfixExpression.Add(number);
                        break;
                    
                    case Function currentFunction:
                        bufferStack.Push(currentFunction);
                        break;
                    
                    case Operator currentOperator:
                        if (bufferStack.Count == 0 || bufferStack.Peek() is OpenBracket)
                        {
                            bufferStack.Push(currentOperator);
                        }
                        else if (bufferStack.Peek() is Operator peekOperator &&
                                 peekOperator.Priority < currentOperator.Priority)
                        {
                            bufferStack.Push(currentOperator);
                        }
                        else // if peek is function or is high priority operation then pops values from stack to expression
                        {
                            while (bufferStack.Count != 0 && 
                                   (bufferStack.Peek() is Function || 
                                    bufferStack.Peek() is Operator anotherPeekOperator && 
                                   anotherPeekOperator.Priority > currentOperator.Priority))
                            {
                                postfixExpression.Add(bufferStack.Pop());
                            }
                            bufferStack.Push(currentOperator);
                        }
                        break;
                    
                    case OpenBracket _:
                        bufferStack.Push(expressionElement);
                        break;  
                    
                    case CloseBracket _:
                        while (!(bufferStack.Peek() is OpenBracket))
                        {
                            postfixExpression.Add(bufferStack.Pop());
                        }
                        bufferStack.Pop();
                        break;
                }
            }

            while (bufferStack.Count > 0)
            {
                postfixExpression.Add(bufferStack.Pop());
            }

            return postfixExpression;
        }
    }
}