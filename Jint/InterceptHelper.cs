using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint.Native;
using Jint.Runtime;
using Jint.Runtime.Environments;
using Jint.Runtime.Interpreter;
using Jint.Runtime.Interpreter.Expressions;
using static Jint.Runtime.Environments.Environment;

namespace Jint
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public class InterceptHelper
    {
        /// <summary>
        /// 拦截器
        /// </summary>
        public static Func<InterceptType, object?[], object?>? Intercept { set; get; }
        public enum InterceptType
        {
            GetProperty = 1,
            GetOwnProperty,
            JintStatementBefore,
            JintStatementAfter,
            JintExpressionBefore,
            JintExpressionAfter,
            GlobalTryGetBinding,
            JintFunctionDefinitionBefore,
        }
        public static JsValue GetValue(Engine engine, string name)
        {
            return GetValue(engine, name, out _);
        }
        public static JsValue GetValue(Engine engine, string name, out Runtime.Environments.Environment? environmentRecord)
        {
            var env = engine.ExecutionContext.LexicalEnvironment;
            var value = JintEnvironment.TryGetIdentifierEnvironmentWithBindingValue(env, new BindingName(name), StrictModeScope.IsStrictModeCode, out environmentRecord, out var temp)
                ? temp
                : JsValue.Undefined;
            return value;
        }
        public static void SetValue(Engine engine, string name, JsValue valeu)
        {
            engine.ExecutionContext.LexicalEnvironment.SetMutableBinding(name, valeu, true);
        }
        public static Completion Execute(Engine engine, NodeList<Statement> statements)
        {
            var list = new JintStatementList(null, statements);
            Completion result = Completion.Empty();
            try
            {
                if (engine._activeEvaluationContext == null)
                {
                    return result;
                }
                result = list.Execute(engine._activeEvaluationContext);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public static Completion Execute(Engine engine, Node node)
        {
            if (node is Statement statement)
            {
                return Execute(engine, NodeList.From(new[] { statement }));
            }
            else if (node is Expression expression)
            {
                if (engine._activeEvaluationContext == null)
                {
                    return Completion.Empty();
                }
                var je = JintExpression.Build(expression);
                var res = je.GetValue(engine._activeEvaluationContext);
                return new Completion(CompletionType.Return, res, expression);
            }
            else
            {
                return default;
            }
        }
    }
}
