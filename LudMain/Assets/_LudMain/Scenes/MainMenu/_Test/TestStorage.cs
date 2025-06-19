using Firebase.Database;
using Firebase.Extensions;
using System;
using UnityEngine;

public class TestStorage : MonoBehaviour
{
    async void Start()
    {
        //await Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => 
        //{
        //    var dependencyStatus = task.Result;
        //    if (dependencyStatus != Firebase.DependencyStatus.Available)
        //    {
        //        UnityEngine.Debug.LogError(System.String.Format(
        //          "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
        //    }
        //    else
        //    {

        //    }
        //});

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        await reference.Child("MainMenuScene")
        .Child("FoundraisingSegment")
        .Child("CollectedMoney")
        .GetValueAsync().ContinueWithOnMainThread(task =>
        { 
            if (task.IsFaulted)
            {
                Debug.Log(task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(Convert.ToInt32(snapshot.Value));
            }
        });
    }
}
