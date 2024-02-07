using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Debug.Gizmos
{
    public interface ISearchGizmosConfig
    {
        bool IsEnabled { get; }
        float Duration { get; }
        
        float AreaWidth { get; }
        Color SuccessAreaColor { get; }
        Color FailAreaColor { get; }
        
        float TargetLineWidth { get; }
        Color TargetLineColor { get; }
    }
}