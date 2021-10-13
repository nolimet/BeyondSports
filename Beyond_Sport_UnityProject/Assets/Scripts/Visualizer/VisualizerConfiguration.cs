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
        private TeamColor fallbackTeamColor;

        [SerializeField]
        private TeamColor[] teamColors;

        public Color GetTeamColor(int teamID)
        {
            return TeamColors.TryGetValue(teamID, out Color teamColor) ? teamColor : fallbackTeamColor.Color;
        }

        public void SetupTeamColorLookup()
        {
            TeamColors = teamColors.ToDictionary(k => k.Id, v => v.Color);
        }

        public IReadOnlyDictionary<int, Color> TeamColors { get; private set; }
        public TeamColor FallbackTeamColor => fallbackTeamColor;

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