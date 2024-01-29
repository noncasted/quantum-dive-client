using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Hitboxes.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HitboxRoutes.ConfigName,
        menuName = HitboxRoutes.ConfigPath)]
    public class HitboxConfigAsset : ScriptableObject, IHitboxConfig
    {
        [SerializeField] [Indent] [Min(0f)] private float _radius;

        public float Radius => _radius;
    }
}