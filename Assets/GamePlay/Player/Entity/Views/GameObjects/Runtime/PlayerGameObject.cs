using UnityEngine;

namespace GamePlay.Player.Entity.Views.GameObjects.Runtime
{
    public class PlayerGameObject : IPlayerGameObject
    {
        public PlayerGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
        
        private readonly GameObject _gameObject;

        public string Name => _gameObject.name;
    }
}