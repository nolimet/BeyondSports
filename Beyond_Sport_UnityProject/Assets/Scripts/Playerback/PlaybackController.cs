using BeyondSports.DataReader;
using BeyondSports.Visualizer;
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

        public PlaybackController(TrackingDataReaderService readerService, DataReaderConfiguration readerConfiguration, VisualizerController visualizerController)
        {
            this.readerService = readerService;
            this.readerConfiguration = readerConfiguration;
            this.visualizerController = visualizerController;
        }

        public async Task<(long start, long end)> LoadFirstFrame()
        {
            await readerService.SetReaderPath(readerConfiguration.GetPath());
            var frameRange = await readerService.GetFrameRange();

            visualizerController.ApplyFrame(await readerService.GetFrame(frameRange.start));
            return frameRange;
        }

        public void JumpToFrame(int value)
        {
        }
    }
}