using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Remote
{
    [DisallowMultipleComponent]
    public class RemoteSwordViewSetup : EntitySetupView, IEntityViewFactory
    {
        [SerializeField] private AttackAreaFactory _attackArea;

        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            _attackArea.Create(services, utils);
        }
    }
}