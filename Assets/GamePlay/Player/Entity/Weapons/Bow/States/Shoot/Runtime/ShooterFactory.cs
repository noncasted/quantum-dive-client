using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime
{
    public abstract class ShooterFactory : ScriptableObject, IComponentFactory
    {
        public abstract void Create(IServiceCollection services, IScopedEntityUtils utils);
    }
}