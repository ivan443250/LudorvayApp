using Cysharp.Threading.Tasks;
using Firebase.Database;
using LudMain.DataHolding;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace LudMain.MainMenu.FoundRaisingSegment
{
    public class FoundraisingSegmentDataLoader : DataLoader
    {
        private readonly IPictureLoader _pictureLoader;

        public FoundraisingSegmentDataLoader(IRepository repository,
            IDataSaver dataSaver,
            IPictureLoader pictureLoader) 
            : base(repository, dataSaver) 
        {
            _pictureLoader = pictureLoader;
        }

        public override void StartLoadData(bool isDeviceDataUpdated, TaskCompletionSource<UniTask> tcs)
        {
            tcs.SetResult(LoadData(isDeviceDataUpdated, ConnectWithDatabase()));
        }

        private async UniTask<FoundRaisingSegmentData> ConnectWithDatabase()
        {
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

            DataSnapshot snapshot = await reference
            .Child(Constants.CurrentScene)
            .Child(Constants.CurrentSegment)
            .GetValueAsync();

            string pictureRef = snapshot.Child(Constants.PictureRef).Value.ToString();
            Texture2D texture = await _pictureLoader.LoadPicture(pictureRef);

            return new FoundRaisingSegmentData(
                snapshot.Child(Constants.Title).Value.ToString(),
                snapshot.Child(Constants.Description).Value.ToString(),
                Convert.ToInt32(snapshot.Child(Constants.CollectedMoney).Value),
                Convert.ToInt32(snapshot.Child(Constants.NeedMoney).Value),
                new SerilizableSprite(texture));
        }

        private class Constants
        {
            public const string CurrentScene = "MainMenuScene";
            public const string CurrentSegment = "FoundraisingSegment";

            public const string Title = "MainTitle";
            public const string Description = "Description";
            public const string CollectedMoney = "CollectedMoney";
            public const string NeedMoney = "NeedMoney";

            public const string PictureRef = "ImageURL";
        }
    }
}
