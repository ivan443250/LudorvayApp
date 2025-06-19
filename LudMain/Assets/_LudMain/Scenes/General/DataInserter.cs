using LudMain.DataHolding;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LudMain.General
{
    public abstract class DataInserter<T> : BaseDataInserter where T : Data
    {
        protected abstract void InsertData(T data);

        protected virtual void ShowLoading() { }

        private IRepository _repository;
        private IMainDataLoader _mainDataLoader;

        [Inject]
        public void Construct(IRepository repository, IMainDataLoader mainDataLoader)
        {
            _repository = repository;

            _mainDataLoader = mainDataLoader;

            Construct();

            StartInsertion();
        }

        protected virtual void Construct() { }

        public sealed override void StartInsertion()
        {
            if (_mainDataLoader.State == MainDataLoaderState.LoadingProcess)
                ShowLoading();
            else if (_repository.TryGetData(out T data))
                InsertData(data);

            //guarantee that HandleNewRepositoryDataSet() was not sub before
            _repository.UnsubscribeFromDataChange(HandleNewRepositoryDataSet);

            _repository.SubscribeOnDataChange(HandleNewRepositoryDataSet);
        }

        public sealed override void EndInsertion()
        {
            _repository?.UnsubscribeFromDataChange(HandleNewRepositoryDataSet);
        }

        private void OnDestroy()
        {
            EndInsertion();
        }

        private void HandleNewRepositoryDataSet(Data data)
        {
            if (data is not T needData) return;

            InsertData(needData);
        }
    }

    public abstract class BaseDataInserter : MonoBehaviour
    {
        public abstract void StartInsertion();
        public abstract void EndInsertion();

        public abstract HashSet<Type> GetDataLoaders();
    }
}
