using UnityEngine;

namespace GamePlay.Services.Combat.Targets.Registry.Abstract
{
    public interface ITargetRegistryGizmosConfig
    {
        bool IsEnabled { get; }
        float Duration { get; }
        
        float LineWidth { get; }
        Color LineColor { get; }
    }
}