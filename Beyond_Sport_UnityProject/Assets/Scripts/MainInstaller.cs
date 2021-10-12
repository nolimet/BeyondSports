using BeyondSports.DataReader;
using BeyondSports.Visualizer;
using UnityEngine;
using Zenject;

namespace BeyondSports
{
    [CreateAssetMenu(fileName = "Main Installer", menuName = "Installers/Main Installer")]
    public class MainInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private DataReaderConfiguration dataReaderConfiguration;

        public override void InstallBindings()
        {
            Container.BindInstance(dataReaderConfiguration).AsSingle();

            Container.Bind<TrackingDataReaderService>().ToSelf().AsSingle();
            Container.Bind<VisualizerController>().ToSelf().AsSingle();
        }
    }
}