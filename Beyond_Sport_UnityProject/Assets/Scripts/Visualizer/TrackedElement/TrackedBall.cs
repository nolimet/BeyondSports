using BeyondSports.DataReader;
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
        public void ApplyFrame(TrackedBallData framedata)
        {
            transform.position = framedata.position;
        }

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