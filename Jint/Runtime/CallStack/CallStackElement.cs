#nullable enable

using Esprima;
using Esprima.Ast;
using Jint.Native.Function;
using Jint.Runtime.Interpreter.Expressions;

namespace Jint.Runtime.CallStack
{
    internal readonly struct CallStackElement
    {
        public CallStackElement(
            IFunctionInstance function,
            JintExpression expression)
        {
            Function = function;
            Expression = expression;
        }

        public readonly IFunctionInstance Function;
        public readonly JintExpression? Expression;

        public Location Location =>
            Expression?._expression.Location ?? ((Node?) Function.FunctionDefinition?.Function)?.Location ?? default;

        public NodeList<Expression>? Arguments =>
            Function.FunctionDefinition?.Function.Params;

        public override string ToString()
        {
            var name = TypeConverter.ToString(Function.Get(CommonProperties.Name));

            if (string.IsNullOrWhiteSpace(name))
            {
                if (Expression is not null)
                {
                    name = JintExpression.ToString(Expression._expression);
                }
            }
            
            return name ?? "(anonymous)";
        }
    }
}
