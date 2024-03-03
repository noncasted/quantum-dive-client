using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RotationRoutes.ConfigName,
        menuName = RotationRoutes.ConfigPath)]
    public class RotationConfigAsset : ScriptableObject
    {
        [SerializeField] [Indent] private float _distance;

        public float Distance => _distance;
    }
}