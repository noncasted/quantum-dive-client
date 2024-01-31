namespace GamePlay.Player.Upgrades.Events
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