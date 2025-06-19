using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

namespace LudMain.DataHolding
{
    public interface IDataLoader
    {
        void StartLoadData(bool isDeviceDataUpdated, TaskCompletionSource<UniTask> tcs);
    }
}
