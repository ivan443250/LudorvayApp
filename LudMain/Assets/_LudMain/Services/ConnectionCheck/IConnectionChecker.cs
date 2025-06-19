using Cysharp.Threading.Tasks;

namespace LudMain.Connection
{
    public interface IConnectionChecker
    {
        UniTask<bool> CheckConnection();
    }
}