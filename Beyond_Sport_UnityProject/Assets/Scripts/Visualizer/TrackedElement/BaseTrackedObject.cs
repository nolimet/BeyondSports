using UnityEngine;

namespace BeyondSports.Visualizer
{
    public abstract class BaseTrackedObject : MonoBehaviour
    {
        [SerializeField]
        private Renderer[] renderers;

        public int id { get; private set; }

        protected void SetColor(Color color)
        {
            foreach (var renderer in renderers)
            {
                renderer.material.color = color;
            }
        }

        public void SetActive(bool isActive)
        {
            foreach (var renderer in renderers)
            {
                renderer.enabled = isActive;
            }
        }
    }
}