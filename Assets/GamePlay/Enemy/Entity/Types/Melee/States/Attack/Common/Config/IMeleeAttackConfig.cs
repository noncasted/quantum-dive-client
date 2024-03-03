using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Config
{
    public interface IMeleeAttackConfig
    {
        float AttackRange { get; }
        float PushForce { get; }
        float DashTime { get; }
        float DashDistance { get; }
        AnimationCurve DashCurve { get; }
    }
}