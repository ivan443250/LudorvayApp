using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LudMain.DataHolding
{
    public interface IPictureLoader
    {
        UniTask<Texture2D> LoadPicture(string url);
    }
}
