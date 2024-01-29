namespace GamePlay.Player.Services.Upgrades.Events
{
    public readonly struct ProjectilesAmountMultiplierEvent : IMultiplierEvent
    {
        public ProjectilesAmountMultiplierEvent(float multiplier)
        {
            Value = multiplier;
        }

        public float Value { get; }
    }
}