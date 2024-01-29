namespace GamePlay.Player.Services.Upgrades.Events
{
    public readonly struct SpreadingMultiplierEvent : IMultiplierEvent
    {
        public SpreadingMultiplierEvent(float multiplier)
        {
            Value = multiplier;
        }

        public float Value { get; }
    }
}