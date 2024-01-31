namespace GamePlay.Player.Upgrades.Events
{
    public readonly struct ProjectilesAmountAddEvent : IAddEvent
    {
        public ProjectilesAmountAddEvent(int add)
        {
            Value = add;
        }

        public int Value { get; }
    }
}