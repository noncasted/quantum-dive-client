namespace GamePlay.Player.Upgrades.Events
{
    public readonly struct ShotDelayMultiplierEvent : IMultiplierEvent
    {
        public ShotDelayMultiplierEvent(float multiplier)
        {
            Value = multiplier;
        }

        public float Value { get; }
    }
}