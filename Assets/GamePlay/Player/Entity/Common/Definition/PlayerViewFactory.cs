using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Common.Definition
{
    [DisallowMultipleComponent]
    public abstract class PlayerViewFactory : MonoBehaviour, IScopedEntityViewFactory
    {
        [SerializeField] private LifetimeScope _scope;
        public LifetimeScope Scope => _scope;
        
        public abstract void CreateViews(IServiceCollection services, IScopedEntityUtils utils);
    }
}