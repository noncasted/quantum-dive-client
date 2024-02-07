namespace GamePlay.Enemies.Updater.Runtime
{
    public interface IRatesConfig
    {
        float TargetSearchRate { get; }
        float PathRecalculateRate { get; }
        float StateSelectionRate { get; }
    }
}