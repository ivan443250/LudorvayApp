using Cysharp.Threading.Tasks;
using Firebase.Database;
using System;

namespace LudMain.DataHolding
{
    public class DatabaseLastUpdateChecker : IDatabaseLastUpdateChecker
    {
        private readonly IDataSaver _dataSaver;

        public DatabaseLastUpdateChecker(IDataSaver dataSaver) 
        {
            _dataSaver = dataSaver;
        }

        public async UniTask<bool> IsDeviceDataUpdated()
        {
            DateTime databaseUpdate = await GetLastDatabaseUpdate();

            if (_dataSaver.TryLoadData(out LastUpdateData data) == false)
                return false;

            if (DateTime.TryParse(data.LastUpdateOnDevice, out DateTime lastUpdateDevice) == false)
                return false;

            return lastUpdateDevice > databaseUpdate;
        }

        private async UniTask<DateTime> GetLastDatabaseUpdate()
        {
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

            DataSnapshot snapshot = await reference.Child(Constants.LastUpdate).GetValueAsync();

            if (DateTime.TryParse(snapshot.Value.ToString(), out DateTime lastUpdateDatabase) == false)
                lastUpdateDatabase = new DateTime(0, 0, 0, 0, 0, 0);

            return lastUpdateDatabase;
        }

        private class Constants
        {
            public const string LastUpdate = "LastUpdate";
        }
    }
}
