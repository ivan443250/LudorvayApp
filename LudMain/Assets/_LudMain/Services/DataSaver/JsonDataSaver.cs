using System.IO;
using UnityEngine;

namespace LudMain.DataHolding
{
    public class JsonDataSaver : IDataSaver
    {
        public string SaveDataPath => _saveDataPath;

        private readonly string _saveDataPath;

        public JsonDataSaver(string saveDataPath)
        {
            _saveDataPath = saveDataPath;
        }

        public void SaveData(Data data)
        {
            string path = SaveDataPath + "/" + data.GetType().Name + ".json";

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(data.Serialize());
            }
        }

        public bool TryLoadData<T>(out T data) where T : Data
        {
            data = LoadData<T>();

            return data != null;
        }

        public T LoadData<T>() where T : Data
        {
            string path = SaveDataPath + "/" + typeof(T).Name + ".json";

            if (File.Exists(path) == false)
                return null;

            string text;

            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }

            return JsonUtility.FromJson<T>(text);
        }
    }
}
