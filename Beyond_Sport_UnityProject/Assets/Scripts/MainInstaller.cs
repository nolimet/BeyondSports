using BeyondSports.DataReader;
using BeyondSports.Visualizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BeyondSports
{
    [CreateAssetMenu(fileName = "Main Installer", menuName = "Installers/Main Installer")]
    public class MainInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private ReaderTypes readerType;

        public override void InstallBindings()
        {
            switch (readerType)
            {
                case ReaderTypes.None:
                    break;

                case ReaderTypes.StaticSoccer:
                    Container.Bind<IDataReader>().To<StaticSoccerDataReader>().AsTransient();
                    break;
            }
            Container.Bind<TrackingDataReaderService>().ToSelf().AsSingle();
            Container.Bind<VisualizerController>().ToSelf().AsSingle();
        }
    }
}