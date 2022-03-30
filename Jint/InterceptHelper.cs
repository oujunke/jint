using Esprima.Ast;
using Jint.Collections;
using Jint.Native;
using Jint.Native.Object;
using Jint.Runtime;
using Jint.Runtime.Environments;
using Jint.Runtime.Interpreter;
using Jint.Runtime.Interpreter.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jint.Runtime.Environments.EnvironmentRecord;

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
        public static Func<InterceptType, object[], object> Intercept;
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
            return GetValue(engine,name,out _);
        }
        public static JsValue GetValue(Engine engine, string name,out EnvironmentRecord environmentRecord)
        {
            var env = engine.ExecutionContext.LexicalEnvironment;
            var value = JintEnvironment.TryGetIdentifierEnvironmentWithBindingValue(env, new BindingName(name), StrictModeScope.IsStrictModeCode, out environmentRecord, out var temp)
                ? temp
                : JsValue.Undefined;
            return value;
        }
        public static void SetValue(Engine engine, string name, JsValue valeu)
        {
            engine.ExecutionContext.LexicalEnvironment.SetMutableBinding(name,valeu,true);
        }
        public static Completion Execute(Engine engine, NodeList<Statement> statements)
        {
            var list = new JintStatementList(null, statements);
            Completion result;
            try
            {
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
                return Execute(engine, NodeList.Create(new[] { statement })); 
            }
            else if (node is Expression expression)
            {
                return JintExpression.Build(engine, expression).GetValue(engine._activeEvaluationContext);
            }
            else
            {
                return default;
            }
        }
    }
}
