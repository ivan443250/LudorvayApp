using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace LudMain.DataHolding
{
    public class PictureLoader : IPictureLoader
    {
        public async UniTask<Texture2D> LoadPicture(string url)
        {
            try
            {
                using UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

                await request.SendWebRequest();

                Texture2D myTexture = DownloadHandlerTexture.GetContent(request);
                return myTexture;
            }
            catch
            {
                Debug.Log($"Picture in {url} was not loaded");
                return null;
            }
        }
    }
}
