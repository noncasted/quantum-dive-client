namespace GamePlay.Player.Upgrades.Events
{
    public readonly struct MagazineAddEvent : IAddEvent
    {
        public MagazineAddEvent(int add)
        {
            Value = add;
        }

        public int Value { get; }
    }
}