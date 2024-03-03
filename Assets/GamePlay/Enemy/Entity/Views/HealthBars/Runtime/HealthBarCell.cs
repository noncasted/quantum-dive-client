using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.HealthBars.Runtime
{
    [DisallowMultipleComponent]
    public class HealthBarCell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _fill;

        public void Show()
        {
            _fill.enabled = true;
        }

        public void Hide()
        {
            _fill.enabled = false;
        }
    }
}