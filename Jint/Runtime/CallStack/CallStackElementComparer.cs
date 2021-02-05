#nullable enable

using System.Collections.Generic;

namespace Jint.Runtime.CallStack
{
    internal sealed class CallStackElementComparer: IEqualityComparer<CallStackElement>
    {
        public static readonly CallStackElementComparer Instance = new();
        
        private CallStackElementComparer()
        {
        }

        public bool Equals(CallStackElement x, CallStackElement y)
        {
            if (x.Function.FunctionDefinition is not null)
            {
                return ReferenceEquals(x.Function.FunctionDefinition, y.Function.FunctionDefinition);
            }
            
            return ReferenceEquals(x.Function, y.Function);
        }

        public int GetHashCode(CallStackElement obj)
        {           
            if (obj.Function.FunctionDefinition is not null)
            {
                return obj.Function.FunctionDefinition.GetHashCode();
            }
            return obj.Function.GetHashCode();
        }
    }
}
