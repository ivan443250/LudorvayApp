using Cysharp.Threading.Tasks;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace LudMain.Connection
{
    public class ConnectionChecker : IConnectionChecker
    {
        private readonly ICoroutineManager _coroutineManager;

        private Coroutine _checkConnectionRoutine;

        public ConnectionChecker(ICoroutineManager coroutineManager)
        {
            _coroutineManager = coroutineManager;
        }

        public async UniTask<bool> CheckConnection()
        {
            TaskCompletionSource<bool> tcs = new();

            _checkConnectionRoutine = _coroutineManager.StartCoroutine(CheckConnectionRoutine(tcs));

            return await tcs.Task;
        }

        private IEnumerator CheckConnectionRoutine(TaskCompletionSource<bool> tcs)
        {
            UnityWebRequest request = UnityWebRequest.Get("https://www.google.com");

            yield return request.SendWebRequest();

            tcs.SetResult(request.result != UnityWebRequest.Result.ConnectionError);
        }

        private void OnDisable()
        {
            if (_checkConnectionRoutine != null)
                _coroutineManager.StopCoroutine(_checkConnectionRoutine);
        }
    }
}