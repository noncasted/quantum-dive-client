namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.Spreadings
{
    public interface ISpreadingData
    {
        float Value { get; }

        void SetValue(float value);
        void AddMultiplier(float multiplier);
    }
}