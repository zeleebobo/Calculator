using Calculator;
using Calculator.Evaluator;
using Calculator.ExpressionElements;
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
    }
}