using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime
{
    public class BowGameObject : IBowGameObject
    {
        public BowGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        private readonly GameObject _gameObject;
        
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