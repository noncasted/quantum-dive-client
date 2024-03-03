using GamePlay.Player.Entity.States.Runs.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RunRoutes.ConfigName,
        menuName = RunRoutes.ConfigPath)]
    public class RunConfigAsset : ScriptableObject
    {
        [SerializeField] [Indent] [Min(0f)] private float _speed;

        public float Speed => _speed;
    }
}