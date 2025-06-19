using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

namespace LudMain.DataHolding
{
    public abstract class DataLoader : IDataLoader
    {
        public abstract void StartLoadData(bool isDeviceDataUpdated, TaskCompletionSource<UniTask> tcs);

        private readonly IRepository _repository;
        private readonly IDataSaver _dataSaver;

        public DataLoader(IRepository repository, IDataSaver dataSaver)
        {
            _repository = repository;
            _dataSaver = dataSaver;
        }

        protected async UniTask LoadData<T>(bool isDeviceDataUpdated, UniTask<T> connectWithDatabase) where T : Data
        {
            Debug.Log("data was " + (isDeviceDataUpdated ? "" : "not ") + "save");

            if (isDeviceDataUpdated && _dataSaver.TryLoadData(out T data))
            {
                _repository.SetData(data);
                return;
            }

            data = await connectWithDatabase;
            _repository.SetData(data);
            _dataSaver.SaveData(data);
        }
    }
}
