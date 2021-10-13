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

        [SerializeField]
        private Visualizer.TrackedObject humanoidPrefab;

        [SerializeField]
        private TrackedBall ballPrefab;

        public override void InstallBindings()
        {
            Container.BindInstance(dataReaderConfiguration).AsSingle();

            Container.Bind<TrackingDataReaderService>().ToSelf().AsSingle();
            Container.Bind<VisualizerController>().ToSelf().AsSingle();

            Container.BindFactory<Visualizer.TrackedObject, Visualizer.TrackedObject.Factory>().FromComponentInNewPrefab(humanoidPrefab);
            Container.BindFactory<TrackedBall, TrackedBall.Factory>().FromComponentInNewPrefab(ballPrefab);
        }
    }
}