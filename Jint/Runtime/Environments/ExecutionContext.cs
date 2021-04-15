using Jint.Native;

namespace Jint.Runtime.Environments
{
    public readonly struct ExecutionContext
    {
        public ExecutionContext(
            LexicalEnvironment lexicalEnvironment,
            LexicalEnvironment variableEnvironment)
        {
            LexicalEnvironment = lexicalEnvironment;
            VariableEnvironment = variableEnvironment;
        }

        public readonly LexicalEnvironment LexicalEnvironment;
        public readonly LexicalEnvironment VariableEnvironment;

        public ExecutionContext UpdateLexicalEnvironment(LexicalEnvironment lexicalEnvironment)
        {
            return new ExecutionContext(lexicalEnvironment, VariableEnvironment);
        }

        public ExecutionContext UpdateVariableEnvironment(LexicalEnvironment variableEnvironment)
        {
            return new ExecutionContext(LexicalEnvironment, variableEnvironment);
        }
        /// <summary>
        /// 获得变量
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strict"></param>
        /// <param name="record"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetBinding(string name,
            bool strict,
            out EnvironmentRecord record,
            out JsValue value)
        {
            EnvironmentRecord.BindingName bindingName = new EnvironmentRecord.BindingName(name);
            if (LexicalEnvironment.TryGetIdentifierEnvironmentWithBindingValue(LexicalEnvironment, in bindingName, strict, out record, out value))
            {
                return true;
            }
            else if (LexicalEnvironment.TryGetIdentifierEnvironmentWithBindingValue(VariableEnvironment, in bindingName, strict, out record, out value))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获得变量
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strict"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetBinding(string name,
           bool strict,
           out JsValue value)
        {
            return TryGetBinding(name,strict,out _,out value);
        }
    }
}
