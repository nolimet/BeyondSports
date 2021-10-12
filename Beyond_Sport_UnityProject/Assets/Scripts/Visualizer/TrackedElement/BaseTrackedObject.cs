using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}