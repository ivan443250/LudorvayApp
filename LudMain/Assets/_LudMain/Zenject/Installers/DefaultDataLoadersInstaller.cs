using LudMain.DataHolding;
using LudMain.Events;
using LudMain.MainMenu.FoundRaisingSegment;
using Zenject;

namespace LudMain
{
    public class DefaultDataLoadersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDataLoader>()
                .To<EventsSegmentDataLoader>()
                .AsSingle();

            Container
                .Bind<IDataLoader>()
                .To<FoundraisingSegmentDataLoader>()
                .AsSingle();
        }
    }
}