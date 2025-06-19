using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudMain.DataHolding
{
    public class MainDataLoader : IMainDataLoader
    {
        public MainDataLoaderState State => _currentState;

        private MainDataLoaderState _currentState;

        private readonly List<IDataLoader> _dataLoaders;
        private readonly IDataSaver _dataSaver;
        private readonly IDatabaseLastUpdateChecker _updateChecker;

        public MainDataLoader(List<IDataLoader> dataLoaders,
            IDataSaver dataSaver,
            IDatabaseLastUpdateChecker updateChecker)
        {
            _currentState = MainDataLoaderState.Default;

            _dataLoaders = dataLoaders;
            _dataSaver = dataSaver;
            _updateChecker = updateChecker;
        }

        public void UpdateData(HashSet<Type> dataLoaderTypes = null)
        {
            if (_currentState == MainDataLoaderState.LoadingProcess)
                return;

            _ = LoadData(dataLoaderTypes);
        }

        public async UniTask LoadData(HashSet<Type> dataLoaderTypes = null)
        {
            _currentState = MainDataLoaderState.LoadingProcess;

            bool isDeviceDataUpdated = await _updateChecker.IsDeviceDataUpdated();

            IEnumerable<IDataLoader> selectedDataLoaders = dataLoaderTypes == null ?
                _dataLoaders :
                _dataLoaders.Where(l => dataLoaderTypes.Contains(l.GetType()));

            foreach (IDataLoader loader in selectedDataLoaders)
            {
                TaskCompletionSource<UniTask> tcs = new TaskCompletionSource<UniTask>();
                loader.StartLoadData(isDeviceDataUpdated, tcs);
                await tcs.Task.Result;
            }

            if (isDeviceDataUpdated == false) 
                _dataSaver.SaveData(new LastUpdateData(DateTime.UtcNow.ToString()));

            _currentState = MainDataLoaderState.Default;
        }
    }
}
