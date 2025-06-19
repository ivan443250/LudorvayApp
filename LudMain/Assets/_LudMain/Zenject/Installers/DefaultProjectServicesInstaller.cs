using LudMain.Connection;
using LudMain.DataHolding;
using UnityEngine;
using Zenject;

namespace LudMain
{
    public class DefaultProjectServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineManager>().FromInstance(CoroutineManager.Instance).AsSingle();

            Container.Bind<IConnectionChecker>().To<ConnectionChecker>().AsSingle();

            Container.Bind<IRepository>().To<Repository>().AsSingle();

            Container.Bind<IMainDataLoader>().To<MainDataLoader>().AsSingle();

            Container.Bind<string>().FromInstance(Application.persistentDataPath).WhenInjectedInto<JsonDataSaver>();
            Container.Bind<IDataSaver>().To<JsonDataSaver>().AsSingle();

            Container.Bind<IDatabaseLastUpdateChecker>().To<DatabaseLastUpdateChecker>().AsSingle();

            Container.Bind<IPictureLoader>().To<PictureLoader>().AsSingle();
        }
    }
}