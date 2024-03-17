using UnityEngine;

namespace Tools.AssembliesViewer.Graph.Nodes.Abstract
{
    public interface IAssemblyNodeView
    {
        Transform Transform { get; }
        Vector2 Position { get; }
        Vector3 WorldPosition { get; }
    }
}