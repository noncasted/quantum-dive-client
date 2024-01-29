namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ProjectilesAmount
{
    public interface IProjectilesAmountData
    {
        int Value { get; }

        void SetValue(int value);
        void AddAmount(int amount);
        void AddMultiplier(float multiplier);
    }
}