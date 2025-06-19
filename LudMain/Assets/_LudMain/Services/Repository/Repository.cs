using System;
using System.Collections.Generic;

namespace LudMain.DataHolding
{
    public class Repository : IRepository
    {
        public event Action<Data> OnDataChange;

        private readonly Dictionary<Type, Data> _datas;

        private Repository()
        {
            _datas = new();
        }

        public bool TryGetData<T>(out T data) where T : Data
        {
            data = GetData<T>();

            return data != null;
        }

        public T GetData<T>() where T : Data
        {
            Data dataForReturn = null;

            Type dataType = typeof(T);
            if (_datas.ContainsKey(dataType))
                dataForReturn = _datas[dataType];

            return dataForReturn?.Clone() as T;
        }

        public void SetData(Data currentData)
        {
            Type dataType = currentData.GetType();

            if (_datas.ContainsKey(dataType) == false)
                _datas.Add(dataType, currentData);

            _datas[dataType] = currentData;

            OnDataChange?.Invoke(currentData);
        }

        public void SubscribeOnDataChange(Action<Data> callback)
        {
            OnDataChange += callback;
        }

        public void UnsubscribeFromDataChange(Action<Data> callback)
        {
            OnDataChange -= callback;
        }
    }
}
