using Jint.Native.Object;

namespace Jint.Native;

public interface IConstructor
{
    ObjectInstance Construct(JsCallArguments arguments, JsValue newTarget);
}
