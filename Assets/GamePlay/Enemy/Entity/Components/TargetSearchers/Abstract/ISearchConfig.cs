namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime
{
    public interface ISearchConfig
    {
        float Radius { get; }
        float StopDistance { get; }
    }
}