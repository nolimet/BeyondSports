using System.Collections.Generic;
using UnityEngine;

namespace BeyondSports.DataReader
{
    public class TrackingData
    {
        public readonly IReadOnlyDictionary<long, TrackingFrame> frames;

        public TrackingData(IReadOnlyDictionary<long, TrackingFrame> frames)
        {
            this.frames = frames;
        }
    }

    public readonly struct TrackingFrame
    {
        public readonly long frameID;
        public readonly TrackedObjectData[] trackedObjects;
        public readonly TrackedBallData[] balls;
        public readonly string[] flags;

        public TrackingFrame(long frameID, TrackedObjectData[] trackedObjects, TrackedBallData[] balls, string[] flags)
        {
            this.frameID = frameID;
            this.trackedObjects = trackedObjects;
            this.balls = balls;
            this.flags = flags;
        }
    }

    public readonly struct TrackedBallData
    {
        public readonly Vector3 position;
        public readonly double speed;

        public TrackedBallData(Vector3 position, double speed)
        {
            this.position = position;
            this.speed = speed;
        }
    }

    public readonly struct TrackedObjectData
    {
        public readonly int id;
        public readonly int teamId;
        public readonly int shirtNumber;
        public readonly Vector3 position;
        public readonly double speed;

        public TrackedObjectData(int id, int teamId, int shirtNumber, Vector3 position, double speed)
        {
            this.id = id;
            this.teamId = teamId;
            this.shirtNumber = shirtNumber;
            this.position = position;
            this.speed = speed;
        }
    }
}