using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BeyondSports.Visualizer
{
    public class TrackedBall : BaseTrackedObject
    {
        public class Factory : PlaceholderFactory<TrackedBall>
        {
            public TrackedBall Create(Color color)
            {
                var newTrackedBall = base.Create();
                newTrackedBall.SetColor(color);

                return newTrackedBall;
            }
        }
    }
}