using UnityEngine;
using Zenject;

namespace BeyondSports.Visualizer
{
    public class TrackedHumanoid : BaseTrackedObject
    {
        public class Factory : PlaceholderFactory<TrackedHumanoid>
        {
            public TrackedHumanoid Create(Color color)
            {
                var newTrackedHumanoid = base.Create();
                newTrackedHumanoid.SetColor(color);

                return newTrackedHumanoid;
            }
        }
    }
}