namespace GamePlay.Player.Entity.Components.Healths.Runtime
{
    public readonly struct PlayerHealthChangeEvent
    {
        public PlayerHealthChangeEvent(int max, int current)
        {
            Max = max;
            Current = current;
        }

        public readonly int Max;
        public readonly int Current;
    }
}