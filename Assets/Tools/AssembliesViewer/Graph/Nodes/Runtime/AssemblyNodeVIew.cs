using Nova;
using TMPro;
using Tools.AssembliesViewer.Domain.Abstract;
using Tools.AssembliesViewer.Graph.Nodes.Abstract;
using UnityEngine;

namespace Tools.AssembliesViewer.Graph.Nodes.Runtime
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public class AssemblyNodeView : MonoBehaviour, IAssemblyNodeView
    {
        [SerializeField] private UIBlock2D _block;
        [SerializeField] private TMP_Text _text;
        
        private IAssembly _assembly;
        
        public UIBlock2D Block => _block;
        public Transform Transform => transform;
        public Vector2 Position => _block.Position.Value;
        public Vector3 WorldPosition => transform.position;

        public void Construct(IAssembly assembly)
        {
            name = assembly.Name;
            _assembly = assembly;
            _text.text = assembly.Name;
        }
    }
}