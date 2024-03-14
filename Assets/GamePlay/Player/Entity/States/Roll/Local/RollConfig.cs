using GamePlay.Player.Entity.States.Roll.Common;
using GamePlay.Player.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    [CreateAssetMenu(fileName = PlayerRollRoutes.ConfigName, menuName = PlayerRollRoutes.ConfigPath)]
    public class RollConfig : ScriptableObject, IRollConfig
    {
        [SerializeField] [Min(0f)] private float _time;
        [SerializeField] [Min(0f)] private float _distance;
        [SerializeField] [CurveRange(0f, 0f, 1f, 1f)] private AnimationCurve _curve;

        public PushParams Params => new(_time, _distance, _curve);
    }
}