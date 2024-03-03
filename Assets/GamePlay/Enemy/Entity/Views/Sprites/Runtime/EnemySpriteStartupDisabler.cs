using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemySpriteStartupDisabler : MonoBehaviour
    {
        private void Awake()
        {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
        }
    }
}