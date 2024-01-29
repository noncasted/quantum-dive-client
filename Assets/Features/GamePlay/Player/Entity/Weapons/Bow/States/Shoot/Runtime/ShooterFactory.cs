using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Runtime
{
    public abstract class ShooterFactory : ScriptableObject, IComponentFactory
    {
        public abstract void Create(IServiceCollection services, ICallbackRegister callbacks);
    }
}