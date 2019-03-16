using System.Runtime.InteropServices.ComTypes;
using Calculator;
using Calculator.Evaluator;
using Calculator.ExpressionElements;
using Calculator.ExpressionElements.Functions;
using Calculator.ExpressionElements.Operators;
using Xunit;

namespace CalculatorTests
{
    public class PostfixEvaluatorTest
    {
        [Fact]
        public void PostfixSimpleEvaluation1()
        {
            var postfixExpression = new MathExpression()
            {
                new Number(1),
                new Number(2),
                new Addition()
            };
            var postfixEvaluator = new PostfixEvaluator();
            var result = postfixEvaluator.Evaluate(postfixExpression);
            Assert.Equal(3, result.Value, 3);
        }
        
        [Fact]
        public void PostfixSimpleEvaluation2()
        {
            var postfixExpression = new MathExpression()
            {
                new Number(1),
                new Number(2),
                new Addition(),
                new Number(3),
                new Addition()
            };
            var postfixEvaluator = new PostfixEvaluator();
            var result = postfixEvaluator.Evaluate(postfixExpression);
            Assert.Equal(6, result.Value, 3);
        }
        
        [Fact]
        public void PostfixEvaluationWithFunctions1()
        {
            var postfixExpression = new MathExpression()
            {
                new Number(0),
                new Sine(),
                new Number(0),
                new Cosine(),
                new Addition()
            };
            var postfixEvaluator = new PostfixEvaluator();
            var result = postfixEvaluator.Evaluate(postfixExpression);
            Assert.Equal(1, result.Value, 3);
        }
        
        [Fact]
        public void PostfixEvaluationWithFunctions2()
        {
            var postfixExpression = new MathExpression()
            {
                new Number(60),
                new Cosine(),
                new Number(30),
                new Sine(),
                new Addition()
            };
            var postfixEvaluator = new PostfixEvaluator();
            var result = postfixEvaluator.Evaluate(postfixExpression);
            Assert.Equal(-1.9404446, result.Value, 3);
        }
    }
}