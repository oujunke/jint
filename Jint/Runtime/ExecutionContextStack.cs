#nullable enable

using System;
using System.Runtime.CompilerServices;
using Jint.Collections;
using Jint.Runtime.Environments;

namespace Jint.Runtime
{
    public sealed class ExecutionContextStack
    {
        private readonly RefStack<ExecutionContext> _stack;

        public ExecutionContextStack(int capacity)
        {
            _stack = new RefStack<ExecutionContext>(capacity);
        }
        /// <summary>
        /// …Ó∏¥÷∆
        /// </summary>
        /// <returns></returns>
        public ExecutionContextStack Clone()
        {
            ExecutionContextStack executionContextStack = new ExecutionContextStack(_stack._array.Length);
            Array.Copy(_stack._array,executionContextStack._stack._array, _stack._array.Length);
            return executionContextStack;
        }
        public void ReplaceTopLexicalEnvironment(LexicalEnvironment newEnv)
        {
            var array = _stack._array;
            var size = _stack._size;
            array[size - 1] = array[size - 1].UpdateLexicalEnvironment(newEnv);
        }

        public void ReplaceTopVariableEnvironment(LexicalEnvironment newEnv)
        {
            var array = _stack._array;
            var size = _stack._size;
            array[size - 1] = array[size - 1].UpdateVariableEnvironment(newEnv);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref readonly ExecutionContext Peek() => ref _stack.Peek();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Push(in ExecutionContext context) => _stack.Push(in context);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Last(out ExecutionContext executionContext) => _stack.Last(out executionContext);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref readonly ExecutionContext Pop() => ref _stack.Pop();
    }
}