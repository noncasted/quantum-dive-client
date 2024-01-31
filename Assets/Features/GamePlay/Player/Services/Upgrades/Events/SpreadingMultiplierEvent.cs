namespace GamePlay.Player.Upgrades.Events
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