using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime
{
    [DisallowMultipleComponent]
    public class AttackAreaFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private AttackAreaConfig _config;
        [SerializeField] private Collider2D _collider;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<AttackArea>()
                .WithParameter<IAttackAreaConfig>(_config)
                .WithParameter(_collider)
                .As<IAttackArea>();
        }
    }
}