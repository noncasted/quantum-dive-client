using System.Collections.Generic;
using Tools.AssembliesViewer.Common;
using UnityEngine;

namespace Tools.AssembliesViewer.Graph.Controller.Runtime
{
    [CreateAssetMenu(fileName = "GraphSave", menuName = AssemblyViewerRoutes.Root + "Save")]
    public class GraphSave : ScriptableObject
    {
        [SerializeField] private NodeSaveDictionary _nodesSave;

        public Dictionary<string, NodeSave> NodesSave => _nodesSave;
    }
}