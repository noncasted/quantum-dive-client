using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordAttackRoutes.RemoteName,
        menuName = SwordAttackRoutes.RemotePath)]
    public class RemoteAttackFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private SwordAttackDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<PlayerRemoteAttack>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}