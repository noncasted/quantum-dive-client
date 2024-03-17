using System;
using UnityEngine;

namespace Tools.AssembliesViewer.Graph.Controller.Runtime
{
    [Serializable]
    public class NodeSave
    {
        [SerializeField] private Vector2 _position;

        public Vector2 Position => _position;

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }
    }
}