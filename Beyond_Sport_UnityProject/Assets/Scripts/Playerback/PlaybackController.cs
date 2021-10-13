using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.Playerback
{
    public class PlaybackController
    {
        private readonly DataReader.TrackingDataReaderService readerService;
        private readonly DataReader.DataReaderConfiguration readerConfiguration;
        private readonly Visualizer.VisualizerController visualizerController;
    }
}