using GamePlay.Player.Entity.Components.DamageProcessors.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DamageProcessorRoutes.ConfigName,
        menuName = DamageProcessorRoutes.ConfigPath)]
    public class DamageProcessorConfigAsset : ScriptableObject
    {
        [SerializeField] private float _damageDelay;

        public float DamageDelay => _damageDelay;
    }
}