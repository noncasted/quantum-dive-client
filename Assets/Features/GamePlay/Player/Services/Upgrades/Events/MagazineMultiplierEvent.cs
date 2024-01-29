namespace GamePlay.Player.Services.Upgrades.Events
{
    public readonly struct MagazineMultiplierEvent : IMultiplierEvent
    {
        public MagazineMultiplierEvent(float multiplier)
        {
            Value = multiplier;
        }

        public float Value { get; }
    }
}