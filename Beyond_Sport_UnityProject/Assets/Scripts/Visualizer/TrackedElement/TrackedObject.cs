using BeyondSports.DataReader;
using UnityEngine;
using Zenject;

namespace BeyondSports.Visualizer
{
    public class TrackedObject : BaseTrackedObject
    {
        public void ApplyFrame(TrackedObjectData frameData, VisualizerConfiguration visualizerConfiguration)
        {
            transform.position = frameData.position;
            SetColor(visualizerConfiguration.GetTeamColor(frameData.teamId));
        }

        public class Factory : PlaceholderFactory<TrackedObject>
        {
            public TrackedObject Create(Color color)
            {
                var newTrackedHumanoid = base.Create();
                newTrackedHumanoid.SetColor(color);

                return newTrackedHumanoid;
            }
        }
    }
}