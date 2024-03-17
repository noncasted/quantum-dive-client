using System.Collections.Generic;
using Global.Debugs.Drawing.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Lifetimes;
using Tools.AssembliesViewer.Domain.Abstract;
using Tools.AssembliesViewer.Graph.Connections.Abstract;
using Tools.AssembliesViewer.Graph.Controller.Abstract;
using Tools.AssembliesViewer.Graph.Nodes.Abstract;
using Tools.AssembliesViewer.Services.DomainProvider.Abstract;

namespace Tools.AssembliesViewer.Graph.Controller.Runtime
{
    public class GraphController :
        IScopeLoadListener,
        IGraphControllerInterceptor,
        IScopeLifetimeListener,
        IUpdatable
    {
        public GraphController(
            IUpdater updater,
            IShapeDrawer drawer,
            GraphMover mover,
            GraphNodeFactory nodeFactory,
            GraphSave save,
            IAssemblyDomain domain)
        {
            _updater = updater;
            _drawer = drawer;
            _mover = mover;
            _nodeFactory = nodeFactory;
            _save = save;
            _domain = domain;
        }

        private readonly IUpdater _updater;
        private readonly IShapeDrawer _drawer;
        private readonly GraphMover _mover;
        private readonly GraphNodeFactory _nodeFactory;
        private readonly GraphSave _save;
        private readonly IAssemblyDomain _domain;

        private readonly Dictionary<IAssembly, IAssemblyNodeView> _nodes = new();
        private readonly List<INodeConnection> _connections = new();

        public void OnLoaded()
        {
            _mover.Start();

            foreach (var assembly in _domain.Assemblies)
            {
                var node = _nodeFactory.CreateNode(assembly);
                _nodes.Add(assembly, node);
            }

            foreach (var (assembly, view) in _nodes)
            {
                foreach (var referencedAssembly in assembly.References)
                {
                    if (_nodes.TryGetValue(referencedAssembly, out var referencedNode) == false)
                        continue;

                    var connection = _nodeFactory.CreateConnection(referencedNode, view);
                    _connections.Add(connection);
                }
            }

            Redraw();
        }

        public void OnLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
        }

        public void SavePositions()
        {
            foreach (var (assembly, node) in _nodes)
            {
                var id = assembly.Id;

                if (_save.NodesSave.ContainsKey(id) == false)
                    _save.NodesSave.Add(id, new NodeSave());
                
                _save.NodesSave[id].SetPosition(node.Position);
            }
        }

        public void Redraw()
        {
            foreach (var connection in _connections)
                connection.Draw(_drawer);
        }

        public void OnUpdate(float delta)
        {
       
        }
    }
}