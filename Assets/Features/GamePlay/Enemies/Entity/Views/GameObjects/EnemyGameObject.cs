using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.GameObjects
{
    public class EnemyGameObject : IEnemyGameObject
    {
        public EnemyGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
        
        private readonly GameObject _gameObject;

        public string Name => _gameObject.name;
    }
}