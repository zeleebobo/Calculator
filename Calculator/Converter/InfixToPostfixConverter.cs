﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Calculator.ExpressionElements;

namespace Calculator.Converter
{
    public class InfixToPostfixConverter : INotationConverter
    {
        private void ValidateInfixExpression(MathExpression expression)
        {
            if (expression.Count == 0)
                throw new InvalidExpressionException("Empty expression");
            
            if (expression.First() is Operator)
                throw new InvalidExpressionException("Expression cannot starts with operator");
            
            if (expression.Last() is Operator || expression.Last() is Function)
                throw new InvalidExpressionException("Expression cannot ends with function or operator");
            
            var openedBrackets = 0;
            for (var i = 0; i < expression.Count; i++)
            {
                var expressionElement = expression[i];
                if (i > 0 && i < expression.Count - 1)
                    expressionElement.Validate(expression[i - 1], expression[i + 1]);
                
                if (expressionElement is OpenBracket)
                    openedBrackets++;
                else if (expressionElement is CloseBracket)
                    openedBrackets--;
            }
            if (openedBrackets > 0)
                throw new InvalidExpressionException("Not closed opening bracket");
            if (openedBrackets < 0)
                throw new InvalidExpressionException("Not opened closing bracket");
        }
        
        public MathExpression Convert(MathExpression convertingExpression)
        {
            ValidateInfixExpression(convertingExpression);
            
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