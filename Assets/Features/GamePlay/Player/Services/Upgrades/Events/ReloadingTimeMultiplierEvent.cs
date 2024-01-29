namespace GamePlay.Player.Services.Upgrades.Events
{
    public readonly struct ReloadingTimeMultiplierEvent : IMultiplierEvent
    {
        public ReloadingTimeMultiplierEvent(float multiplier)
        {
            Value = multiplier;
        }

        public float Value { get; }
    }
}