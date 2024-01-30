using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime
{
    public abstract class ShooterFactory : ScriptableObject, IComponentFactory
    {
        public abstract void Create(IServiceCollection services, IEntityUtils utils);
    }
}