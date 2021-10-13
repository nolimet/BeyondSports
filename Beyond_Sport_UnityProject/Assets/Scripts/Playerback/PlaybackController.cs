using BeyondSports.DataReader;
using BeyondSports.Visualizer;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BeyondSports.Playerback
{
    public class PlaybackController : ITickable
    {
        private readonly TrackingDataReaderService readerService;
        private readonly DataReaderConfiguration readerConfiguration;
        private readonly VisualizerController visualizerController;

        private bool playing = false;
        private float frameTimer = 0;
        private (long start, long end) frameRange;
        private long currentFrame = -1;

        public PlaybackController(TrackingDataReaderService readerService, DataReaderConfiguration readerConfiguration, VisualizerController visualizerController)
        {
            this.readerService = readerService;
            this.readerConfiguration = readerConfiguration;
            this.visualizerController = visualizerController;
        }

        public async Task<(long start, long end)> LoadFirstFrame()
        {
            await readerService.SetReaderPath(readerConfiguration.GetPath());
            frameRange = await readerService.GetFrameRange();

            currentFrame = frameRange.start;
            frameTimer = 1f / readerConfiguration.FramesPerSecond;

            visualizerController.ApplyFrame(await readerService.GetFrame(frameRange.start));
            return frameRange;
        }

        public async Task JumpToFrame(long value)
        {
            visualizerController.ApplyFrame(await readerService.GetFrame(value));
        }

        public void SetPlaying(bool isPlaying)
        {
            playing = isPlaying;

            if (currentFrame > frameRange.end)
            {
                currentFrame = frameRange.start;
            }
        }

        public void Tick()
        {
            if (playing)
            {
                frameTimer -= Time.deltaTime;
                if (frameTimer <= 0)
                {
                    frameTimer += 1f / readerConfiguration.FramesPerSecond;
                    currentFrame++;

                    if (currentFrame > frameRange.end)
                    {
                        playing = false;
                    }
                    else
                    {
                        JumpToFrame(currentFrame);
                    }
                }
            }
        }
    }
}