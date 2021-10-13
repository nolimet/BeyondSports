using BeyondSports.DataReader;
using System.Collections.Generic;

namespace BeyondSports.Visualizer
{
    public class VisualizerController
    {
        private readonly TrackedObject.Factory objectFactory;
        private readonly TrackedBall.Factory ballFactory;

        private readonly List<TrackedObject> trackedObjects = new List<TrackedObject>();
        private readonly List<TrackedBall> trackedBalls = new List<TrackedBall>();

        public VisualizerController(TrackedObject.Factory objectFactory, TrackedBall.Factory ballFactory)
        {
            this.objectFactory = objectFactory;
            this.ballFactory = ballFactory;
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
            }
        }
    }
}