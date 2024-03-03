using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordAttackRoutes.LocalName, menuName = SwordAttackRoutes.LocalPath)]
    public class SwordAttackFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private SwordAttackDefinition _definition;
        [SerializeField] [Indent] private SwordAttackConfig _config;
        [SerializeField] [Indent] private PushParams _pushParams;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<Attack>()
                .WithParameter(_definition)
                .WithParameter(_pushParams)
                .WithParameter<ISwordAttackConfig>(_config)
                .AsCallbackListener();
        }
    }
}