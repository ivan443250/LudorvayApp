using LudMain.Connection;
using LudMain.DataHolding;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace LudMain.Loading
{
    public class LoadingEntryPoint : MonoBehaviour
    {
        [SerializeField] private bool _isOfflineMode;

        [SerializeField] private SceneContext _sceneContext;

        private IConnectionChecker _connectionChecker;
        private IMainDataLoader _mainDataLoader;

        [Inject]
        public void Construct(IConnectionChecker connectionChecker, IMainDataLoader mainDataLoader)
        {
            _connectionChecker = connectionChecker;

            _mainDataLoader = mainDataLoader;
        }

        private async void Awake()
        {
            _sceneContext.Run();

            if (_isOfflineMode)
            {
                SceneManager.LoadScene(Constants.NextSceneName);
                return;
            }

            await _connectionChecker.CheckConnection();

            await _mainDataLoader.LoadData();

            SceneManager.LoadScene(Constants.NextSceneName);
        }

        private class Constants 
        {
            public const string NextSceneName = "MainMenu";
        }
    }
}