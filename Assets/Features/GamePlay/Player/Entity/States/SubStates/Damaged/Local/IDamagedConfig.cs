using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Local
{
    public interface IDamagedConfig
    {
        int FlickAmount { get; }
        Material Material { get; }

        float BasePushDistance { get; }
        float Time { get; }
        AnimationCurve PushCurve { get; }
    }
}