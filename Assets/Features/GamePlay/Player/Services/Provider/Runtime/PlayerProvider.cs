using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Player.Provider.Runtime
{
    public class PlayerProvider : IPlayerProvider, IPlayerPositionProvider
    {
        private IPlayerPosition _position;
        private IHealth _health;

        public Vector2 Position => GetPosition();
        
        public void AssignPlayer(IPlayerPosition position, IHealth health)
        {
            _health = health;
            _position = position;
        }

        private Vector2 GetPosition()
        {
            if (_position == null)
            {
                Debug.LogError("No player found");
                return Vector2.zero;
            }

            return _position.Position;
        }
    }
}