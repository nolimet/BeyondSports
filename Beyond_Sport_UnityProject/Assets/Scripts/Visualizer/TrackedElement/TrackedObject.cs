using UnityEngine;
using Zenject;

namespace BeyondSports.Visualizer
{
    public class TrackedObject : BaseTrackedObject
    {
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