namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Abstract
{
    public interface ISearchConfig
    {
        float Radius { get; }
        float StopDistance { get; }
    }
}