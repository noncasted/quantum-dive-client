using Nova;
using Tools.AssembliesViewer.Graph.View.Abstract;
using UnityEngine;

namespace Tools.AssembliesViewer.Graph.View.Runtime
{
    [DisallowMultipleComponent]
    public class NodesRootView : MonoBehaviour, INodesRootView
    {
        [SerializeField] private UIBlock2D _block;

        public Transform Transform => transform;
        public Vector2 Position => _block.Position.Value;
        
        public void SetPosition(Vector2 position)
        {
            _block.Position.Value = position;
        }
    }
}