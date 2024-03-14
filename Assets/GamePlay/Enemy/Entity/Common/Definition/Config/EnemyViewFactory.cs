using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Enemy.Entity.Common.Definition.Config
{
    [DisallowMultipleComponent]
    public abstract class EnemyViewFactory : MonoBehaviour, IScopedEntityViewFactory
    {
        [SerializeField] private LifetimeScope _scope;
        public LifetimeScope Scope => _scope;
        
        public abstract void CreateViews(IServiceCollection services, IScopedEntityUtils utils);
    }
}