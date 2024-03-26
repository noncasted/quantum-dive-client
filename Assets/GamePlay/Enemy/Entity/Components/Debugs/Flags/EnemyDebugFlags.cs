using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Debugs.Flags
{
    public class EnemyDebugFlags : MonoBehaviour, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
        }
    }
}