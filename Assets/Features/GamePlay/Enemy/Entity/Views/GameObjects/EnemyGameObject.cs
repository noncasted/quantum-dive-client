using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.GameObjects
{
    public class EnemyGameObject : IEnemyGameObject
    {
        public EnemyGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
        
        private readonly GameObject _gameObject;

        public string Name => _gameObject.name;
        
        public void Enable()
        {
            _gameObject.SetActive(true);
        }

        public void Disable()
        {
            _gameObject.SetActive(false);
        }
    }
}