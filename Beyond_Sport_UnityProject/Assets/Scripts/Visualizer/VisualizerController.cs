using BeyondSports.DataReader;
using System.Collections.Generic;

namespace BeyondSports.Visualizer
{
    public class VisualizerController
    {
        private readonly TrackedObject.Factory objectFactory;
        private readonly TrackedBall.Factory ballFactory;
        private readonly VisualizerConfiguration visualizerConfiguration;

        private readonly List<TrackedObject> trackedObjects = new List<TrackedObject>();
        private readonly List<TrackedBall> trackedBalls = new List<TrackedBall>();

        public VisualizerController(TrackedObject.Factory objectFactory, TrackedBall.Factory ballFactory, VisualizerConfiguration visualizerConfiguration)
        {
            this.objectFactory = objectFactory;
            this.ballFactory = ballFactory;
            this.visualizerConfiguration = visualizerConfiguration;
        }

        public void ApplyFrame(TrackingFrame frame)
        {
            if (frame.trackedObjects.Length > trackedObjects.Count)
            {
                int missingObjects = frame.trackedObjects.Length - trackedObjects.Count;
                for (int i = 0; i < missingObjects; i++)
                {
                    trackedObjects.Add(objectFactory.Create());
                }
            }

            if (frame.balls.Length > trackedBalls.Count)
            {
                int missingBalls = frame.balls.Length - trackedBalls.Count;
                for (int i = 0; i < missingBalls; i++)
                {
                    trackedBalls.Add(ballFactory.Create());
                }
            }

            for (int i = 0; i < trackedObjects.Count; i++)
            {
                var trackedObject = trackedObjects[i];
                if (frame.trackedObjects.Length < i)
                {
                    trackedObject.SetActive(true);
                    var FrameTrackedObject = frame.trackedObjects[i];
                    trackedObject.ApplyFrame(FrameTrackedObject, visualizerConfiguration);
                }
                else
                {
                    trackedObject.SetActive(false);
                }
            }

            for (int i = 0; i < trackedBalls.Count; i++)
            {
                var trackedBall = trackedBalls[i];
                if (frame.trackedObjects.Length < i)
                {
                    trackedBall.SetActive(true);
                    var FrameTrackedObject = frame.balls[i];
                    trackedBall.ApplyFrame(FrameTrackedObject);
                }
                else
                {
                    trackedBall.SetActive(false);
                }
            }
        }
    }
}