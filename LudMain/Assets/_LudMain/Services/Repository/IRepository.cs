using System;

namespace LudMain.DataHolding
{
    public interface IRepository
    {
        void SubscribeOnDataChange(Action<Data> callback);
        void UnsubscribeFromDataChange(Action<Data> callback);

        T GetData<T>() where T : Data;
        bool TryGetData<T>(out T data) where T : Data;

        void SetData(Data currentData);
    }
}
