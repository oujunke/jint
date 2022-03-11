using Jint.Collections;
using Jint.Native.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
