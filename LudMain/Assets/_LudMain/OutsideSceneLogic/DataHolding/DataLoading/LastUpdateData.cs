using System;
using UnityEngine;

namespace LudMain.DataHolding
{
    [Serializable]
    public class LastUpdateData : Data
    {
        public string LastUpdateOnDevice;

        public LastUpdateData(string lastUpdateOnDevice)
        {
            LastUpdateOnDevice = lastUpdateOnDevice;
        }

        public override object Clone()
        {
            return new LastUpdateData(LastUpdateOnDevice);
        }

        public override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
