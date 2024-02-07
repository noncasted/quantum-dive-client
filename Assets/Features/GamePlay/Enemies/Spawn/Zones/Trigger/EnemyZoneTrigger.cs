using System;
using GamePlay.Player.Entity.Views.View;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Zones.Trigger
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    public class EnemyZoneTrigger : MonoBehaviour, IEnemyZoneTrigger
    {
        public event Action Entered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPlayerView facade) == false)
            {
                Debug.LogError($"Wrong player trigger with: {other.name}");
                return;
            }
            
            Entered?.Invoke();
        }
    }
}