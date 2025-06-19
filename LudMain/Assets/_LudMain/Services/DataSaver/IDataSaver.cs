namespace LudMain.DataHolding
{
    public interface IDataSaver
    {
        string SaveDataPath { get; }

        T LoadData<T>() where T : Data;
        bool TryLoadData<T>(out T data) where T : Data;

        void SaveData(Data data);
    }
}
