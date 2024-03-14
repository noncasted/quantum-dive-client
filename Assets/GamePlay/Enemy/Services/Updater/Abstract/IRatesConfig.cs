namespace GamePlay.Enemy.Services.Updater.Abstract
{
    public interface IRatesConfig
    {
        float TargetSearchRate { get; }
        float PathRecalculateRate { get; }
        float StateSelectionRate { get; }
    }
}