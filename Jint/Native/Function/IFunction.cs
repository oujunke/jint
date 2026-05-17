using System;
using System.Collections.Generic;
using System.Text;
using Jint.Runtime.Interpreter;

namespace Jint.Native.Function
{
    public interface IFunction : ICallable
    {
        Engine Engine { get; }
        public JintFunctionDefinition? FunctionDefinition { get; }
        public JsValue Get(JsValue property);
    }
}
