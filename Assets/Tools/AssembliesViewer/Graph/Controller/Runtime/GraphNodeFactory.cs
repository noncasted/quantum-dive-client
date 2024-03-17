﻿using Tools.AssembliesViewer.Domain.Abstract;
using Tools.AssembliesViewer.Graph.Connections.Abstract;
using Tools.AssembliesViewer.Graph.Controller.Abstract;
using Tools.AssembliesViewer.Graph.Nodes.Abstract;
using Tools.AssembliesViewer.Graph.View.Abstract;
using UnityEngine;

namespace Tools.AssembliesViewer.Graph.Controller.Runtime
{
    public class GraphNodeFactory
    {
        public GraphNodeFactory(INodesRootView rootView, NodeFactoryConfig config, GraphSave save)
        {
            _rootView = rootView;
            _config = config;
            _save = save;
        }

        private readonly INodesRootView _rootView;
        private readonly NodeFactoryConfig _config;
        private readonly GraphSave _save;

        public IAssemblyNodeView CreateNode(IAssembly assembly, IGraphControllerInterceptor interceptor)
        {
            var position = GetPosition(assembly);
            var view = Object.Instantiate(_config.Prefab, _rootView.Transform);
            view.Block.Position.Value = position;

            view.Construct(assembly, interceptor);

            return view;
        }
        
        public INodeConnection CreateConnection(IAssemblyNodeView from, IAssemblyNodeView to)
        {
            var view = Object.Instantiate(_config.ConnectionPrefab, from.Transform);
            view.Construct(from, to);

            return view;
        }

        private Vector2 GetPosition(IAssembly assembly)
        {
            if (_save.X.TryGetValue(assembly.Id, out var save) == true)
                return new Vector2(_save.X[assembly.Id], _save.Y[assembly.Id]);

            var position = new Vector2(Random.Range(-3000, 3000), Random.Range(-3000, 3000));

            return position;
        }
    }
}