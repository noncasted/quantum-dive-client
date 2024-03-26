using Common.DataTypes.Runtime.Reactive;
using Global.Configs.Upgrades.Abstract;
using Internal.Scopes.Abstract.Instances.Services;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Configuration
{
    public class BowConfig : IBowConfig, IScopeEnableListener
    {
        public BowConfig(
            IUpgrades upgrades,
            ShootDelayUpgrade shotDelay,
            ArrowSpeedUpgrade arrowSpeed,
            DamageUpgrade damage,
            PushForceUpgrade pushForce)
        {
            _upgrades = upgrades;
            _shotDelay = shotDelay;
            _arrowSpeed = arrowSpeed;
            _damage = damage;
            _pushForce = pushForce;
            
            _shotDelay.SetLevel(0);
            _arrowSpeed.SetLevel(0);
            _damage.SetLevel(0);
            _pushForce.SetLevel(0);
        }

        private readonly IUpgrades _upgrades;
        private readonly ShootDelayUpgrade _shotDelay;
        private readonly ArrowSpeedUpgrade _arrowSpeed;
        private readonly DamageUpgrade _damage;
        private readonly PushForceUpgrade _pushForce;

        public IViewableProperty<float> ShotDelay => _shotDelay.Value;
        public IViewableProperty<float> ArrowSpeed => _arrowSpeed.Value; 
        public IViewableProperty<int> Damage => _damage.Value;
        public IViewableProperty<float> PushForce => _pushForce.Value;

        public void OnEnabled()
        {
            _upgrades.Register(_shotDelay);
            _upgrades.Register(_arrowSpeed);
            _upgrades.Register(_damage);
            _upgrades.Register(_pushForce);
        }
    }
}