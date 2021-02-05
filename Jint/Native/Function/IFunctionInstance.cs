using Jint.Runtime.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jint.Native.Function
{
    public interface IFunctionInstance : ICallable
    {
        Engine Engine { get; }
        public JintFunctionDefinition FunctionDefinition { get; }
        public JsValue Get(JsValue property);
    }
}
