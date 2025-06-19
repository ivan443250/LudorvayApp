using Cysharp.Threading.Tasks;
using Firebase.Database;
using LudMain.DataHolding;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace LudMain.Events
{
    public class EventsSegmentDataLoader : DataLoader
    {
        private readonly IPictureLoader _pictureLoader;

        public EventsSegmentDataLoader(IRepository repository,
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

        private async UniTask<EventsSegmentData> ConnectWithDatabase()
        {
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

            DataSnapshot scene = await reference
            .Child(Constants.CurrentScene)
            .GetValueAsync();

            int eventsCount = Convert.ToInt32(scene.Child(Constants.EventsCount).Value);

            DataSnapshot events = scene.Child(Constants.Event);

            DataSnapshot name = events.Child(Constants.Name);
            DataSnapshot description = events.Child(Constants.Description);
            DataSnapshot date = events.Child(Constants.Date);
            DataSnapshot time = events.Child(Constants.Time);
            DataSnapshot imageUrl = events.Child(Constants.ImageUrl);

            EventData[] eventDatas = new EventData[eventsCount];

            for (int i = 0; i < eventsCount; i++)
            {
                string currentName = name.Child(i.ToString()).Value.ToString();
                string currentDescription = description.Child(i.ToString()).Value.ToString();
                string currentDate = date.Child(i.ToString()).Value.ToString();
                string currentTime = time.Child(i.ToString()).Value.ToString();
                string currentImageUrl = imageUrl.Child(i.ToString()).Value.ToString();

                Texture2D texture = await _pictureLoader.LoadPicture(currentImageUrl);
                SerilizableSprite sprite = new SerilizableSprite(texture);

                eventDatas[i] = new EventData(currentName, currentDescription, currentDate, currentTime, sprite);
            }

            return new EventsSegmentData(eventDatas);
        }

        private class Constants
        {
            public const string CurrentScene = "EventScene";

            public const string EventsCount = "EventsCount";
            public const string Event = "Event";

            public const string Name = "Name";
            public const string Description = "Description";
            public const string Date = "Date";
            public const string Time = "Time";
            public const string ImageUrl = "ImageURL";
        }
    }
}
