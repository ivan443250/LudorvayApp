using Firebase.Extensions;
using Firebase.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ImageSet : MonoBehaviour
{
    void Start()
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;

        StorageReference reference = storage.GetReference("gs://ludmain-7a048.appspot.com/MainMenu/SightSlider/Slides/RUKdCtveJuSkQR52TcnzdpZq.png");

        reference.GetDownloadUrlAsync().ContinueWithOnMainThread(task => 
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("Download URL: " + task.Result);
            }
        });
    }
}
