using Common.DataTypes.Runtime.Attributes;
using Global.Configs.Abstract;
using Internal.Scopes.Abstract.Containers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Configuration
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "BowConfig", menuName = BowConfigurationRoutes.Root)]
    public class BowConfigSource : ConfigSource
    {
        [SerializeField] [NestedScriptableObjectField]
        private ShootDelayUpgradeDefinition _shootDelayDefinition;
        
        [SerializeField] [NestedScriptableObjectField]
        private ArrowSpeedUpgradeDefinition _arrowSpeedDefinition;
        
        [SerializeField] [NestedScriptableObjectField]
        private DamageUpgradeDefinition _damageDefinition;
        
        [SerializeField] [NestedScriptableObjectField]
        private PushForceUpgradeDefinition _pushForceDefinition;

        [SerializeField] private float[] _shootDelay;
        [SerializeField] private float[] _arrowSpeed;
        [SerializeField] private int[] _damage;
        [SerializeField] private float[] _pushForce;
        
        public override void CreateInstance(IServiceCollection services)
        {
            var shootDelay = new ShootDelayUpgrade(_shootDelayDefinition, _shootDelay);
            var arrowSpeed = new ArrowSpeedUpgrade(_arrowSpeedDefinition, _arrowSpeed);
            var damage = new DamageUpgrade(_damageDefinition, _damage);
            var pushForce = new PushForceUpgrade(_pushForceDefinition, _pushForce);

            services.Register<BowConfig>()
                .WithParameter(shootDelay)
                .WithParameter(arrowSpeed)
                .WithParameter(damage)
                .WithParameter(pushForce)
                .As<IBowConfig>()
                .AsCallbackListener();
        }
    }
}