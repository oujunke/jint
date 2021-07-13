using Jint.Native;

namespace Jint.Runtime.Environments
{
    public readonly struct Binding
    {
        public Binding(
            JsValue value,
            bool canBeDeleted,
            bool mutable,
            bool strict)
        {
            Value = value;
            CanBeDeleted = canBeDeleted;
            Mutable = mutable;
            Strict = strict;
            ChangeNum = 0;
        }
        public Binding(
            JsValue value,
            bool canBeDeleted,
            bool mutable,
            bool strict, int num)
        {
            Value = value;
            CanBeDeleted = canBeDeleted;
            Mutable = mutable;
            Strict = strict;
            ChangeNum = num;
        }
        public readonly JsValue Value;
        public readonly bool CanBeDeleted;
        public readonly bool Mutable;
        public readonly bool Strict;
        /// <summary>
        /// 更改次数
        /// </summary>
        public readonly int ChangeNum;
        public Binding ChangeValue(JsValue argument)
        {
            return new Binding(argument, CanBeDeleted, Mutable, Strict, ChangeNum + 1);
        }

        public bool IsInitialized() => !(Value is null);
    }
}
