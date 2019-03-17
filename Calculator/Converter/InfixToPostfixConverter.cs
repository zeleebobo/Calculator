using System;
using System.Collections.Generic;
using Calculator.ExpressionElements;
using Calculator.Parser;

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
                    case Number _:
                        postfixExpression.Add(expressionElement);
                        break;
                    case Operator _:
                    case Function _:
                        if (bufferStack.Count == 0 || bufferStack.Peek() is OpenBracket)
                        {
                            bufferStack.Push(expressionElement);
                        }
                        else if (expressionElement is Function || 
                                 (bufferStack.Peek() as Operator).Priority > (expressionElement as Operator).Priority)
                        {
                            bufferStack.Push(expressionElement);
                        }
                        else
                        {
                            while (!(bufferStack.Peek() is OpenBracket) ||
                                   (bufferStack.Peek() as Operator).Priority < (expressionElement as Operator).Priority)
                            {
                                postfixExpression.Add(bufferStack.Pop());
                            }
                            bufferStack.Push(expressionElement);
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