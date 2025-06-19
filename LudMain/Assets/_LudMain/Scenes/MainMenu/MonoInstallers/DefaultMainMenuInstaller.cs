using LudMain.General;
using UnityEngine;
using Zenject;

namespace LudMain.MainMenu
{
    public class DefaultMainMenuInstaller : MonoInstaller
    {
        [SerializeField] private SceneReloader _sceneReloader;

        public override void InstallBindings()
        {
            Container
                .Bind<ISceneReloader>()
                .FromInstance(_sceneReloader);

        }
    }
}