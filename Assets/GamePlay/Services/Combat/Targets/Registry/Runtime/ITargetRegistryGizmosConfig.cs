using UnityEngine;

namespace GamePlay.Targets.Registry.Runtime
{
    public interface ITargetRegistryGizmosConfig
    {
        bool IsEnabled { get; }
        float Duration { get; }
        
        float LineWidth { get; }
        Color LineColor { get; }
    }
}