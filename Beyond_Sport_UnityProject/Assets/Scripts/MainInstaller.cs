using BeyondSports.DataReader;
using BeyondSports.Playerback;
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
        private VisualizerConfiguration visualizerConfiguration;

        [SerializeField]
        private TrackedObject humanoidPrefab;

        [SerializeField]
        private TrackedBall ballPrefab;

        public override void InstallBindings()
        {
            visualizerConfiguration.SetupTeamColorLookup();

            Container.BindInstance(dataReaderConfiguration).AsSingle();
            Container.BindInstance(visualizerConfiguration).AsSingle();

            Container.Bind<TrackingDataReaderService>().ToSelf().AsSingle();
            Container.Bind<VisualizerController>().ToSelf().AsSingle();
            Container.BindInterfacesAndSelfTo<PlaybackController>().AsSingle();

            Container.BindFactory<TrackedObject, TrackedObject.Factory>().FromComponentInNewPrefab(humanoidPrefab);
            Container.BindFactory<TrackedBall, TrackedBall.Factory>().FromComponentInNewPrefab(ballPrefab);
        }
    }
}