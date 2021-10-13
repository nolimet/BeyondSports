using UnityEngine;

namespace BeyondSports.DataReader
{
    public class TrackingData
    {
        public readonly TrackingFrame[] frames;

        public TrackingData(TrackingFrame[] frames)
        {
            this.frames = frames;
        }
    }

    public readonly struct TrackingFrame
    {
        public readonly long frameID;
        public readonly TrackedObject[] trackedObjects;
        public readonly BallData[] balls;
        public readonly string[] flags;

        public TrackingFrame(long frameID, TrackedObject[] trackedObjects, BallData[] balls, string[] flags)
        {
            this.frameID = frameID;
            this.trackedObjects = trackedObjects;
            this.balls = balls;
            this.flags = flags;
        }
    }

    public readonly struct BallData
    {
        public readonly Vector3 position;
        public readonly double speed;

        public BallData(Vector3 position, double speed)
        {
            this.position = position;
            this.speed = speed;
        }
    }

    public readonly struct TrackedObject
    {
        public readonly int id;
        public readonly int teamId;
        public readonly int shirtNumber;
        public readonly Vector3 position;
        public readonly double speed;

        public TrackedObject(int id, int teamId, int shirtNumber, Vector3 position, double speed)
        {
            this.id = id;
            this.teamId = teamId;
            this.shirtNumber = shirtNumber;
            this.position = position;
            this.speed = speed;
        }
    }
}