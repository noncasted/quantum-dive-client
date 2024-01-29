namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ShotDelays
{
    public interface IShotDelayData
    {
        float Value { get; }

        void SetValue(float value);
        void AddMultiplier(float multiplier);
    }
}