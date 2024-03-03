using Global.Configs.Upgrades.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Configuration
{
    public class ArrowSpeedUpgrade : Upgrade<float>
    {
        public ArrowSpeedUpgrade(IUpgradeDefinition definition, float[] levels) : base(definition, levels)
        {
        }
    }
    
    public class ShootDelayUpgrade : Upgrade<float>
    {
        public ShootDelayUpgrade(IUpgradeDefinition definition, float[] levels) : base(definition, levels)
        {
        }
    }

    public class DamageUpgrade : Upgrade<int>
    {
        public DamageUpgrade(IUpgradeDefinition definition, int[] levels) : base(definition, levels)
        {
        }
    }

    public class PushForceUpgrade : Upgrade<float>
    {
        public PushForceUpgrade(IUpgradeDefinition definition, float[] levels) : base(definition, levels)
        {
        }
    }
}