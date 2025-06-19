using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LudMain.DataHolding
{
    public interface IDatabaseLastUpdateChecker
    {
        UniTask<bool> IsDeviceDataUpdated();
    }
}
