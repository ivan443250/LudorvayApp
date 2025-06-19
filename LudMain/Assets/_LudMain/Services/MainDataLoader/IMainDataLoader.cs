using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace LudMain.DataHolding
{
    public interface IMainDataLoader
    {
        MainDataLoaderState State { get; }

        UniTask LoadData(HashSet<Type> dataLoaderTypes = null);

        void UpdateData(HashSet<Type> dataLoaderTypes = null);
    }

    public enum MainDataLoaderState
    {
        Default,
        LoadingProcess
    }
}
