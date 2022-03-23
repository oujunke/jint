using Jint.Collections;
using Jint.Native;
using Jint.Native.Object;
using Jint.Runtime.Environments;
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
        }
        public static JsValue GetValue(Engine engine,string name)
        {
            var env = engine.ExecutionContext.LexicalEnvironment;
            var value = JintEnvironment.TryGetIdentifierEnvironmentWithBindingValue(env, new BindingName(name), StrictModeScope.IsStrictModeCode, out var _,out var temp)
                ? temp
                : JsValue.Undefined;
            return value;
        }
    }
}
