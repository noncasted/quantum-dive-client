using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.Bootstrap
{
    [DisallowMultipleComponent]
    public class SwordViewsBuilder : MonoBehaviour, IPlayerContainerBuilder
    {
        [SerializeField] private AttackAreaFactory _attackArea;
        
        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
        {
            _attackArea.Create(services, callbacks);
        }
    }
}