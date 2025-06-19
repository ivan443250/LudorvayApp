using System;

namespace LudMain.DataHolding
{
    [Serializable]
    public abstract class Data : ICloneable
    {
        public abstract object Clone();

        public abstract string Serialize();
    }
}
