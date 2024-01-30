using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime
{
    [DisallowMultipleComponent]
    public class AttackAreaFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AttackAreaConfig _config;
        [SerializeField] private Collider2D _collider;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<AttackArea>()
                .WithParameter<IAttackAreaConfig>(_config)
                .WithParameter(_collider)
                .As<IAttackArea>();
        }
    }
}