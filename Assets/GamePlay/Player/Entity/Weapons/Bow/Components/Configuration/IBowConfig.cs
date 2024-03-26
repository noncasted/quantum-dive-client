using Common.DataTypes.Runtime.Reactive;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Configuration
{
    public interface IBowConfig
    {
        IViewableProperty<float> ShotDelay { get; }
        IViewableProperty<int> Damage { get; }
        IViewableProperty<float> ArrowSpeed { get; }
        IViewableProperty<float> PushForce { get; }
    }
}