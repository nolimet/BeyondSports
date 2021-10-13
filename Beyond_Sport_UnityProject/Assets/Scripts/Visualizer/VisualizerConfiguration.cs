using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeyondSports.Visualizer
{
    [CreateAssetMenu(fileName = "Visualizer Configuration", menuName = "Configuration/Visualizer")]
    public class VisualizerConfiguration : ScriptableObject
    {
        [SerializeField]
        private TeamColor[] teamColors;

        public IReadOnlyList<TeamColor> TeamColors => teamColors;

        [Serializable]
        public class TeamColor
        {
            [SerializeField]
            private int id;

            [SerializeField]
            private Color color;

            public int Id => id;
            public Color Color => color;
        }
    }
}