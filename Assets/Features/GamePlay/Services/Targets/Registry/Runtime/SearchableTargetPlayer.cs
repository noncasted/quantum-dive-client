using UnityEngine;

namespace GamePlay.Targets.Registry.Runtime
{
    public class SearchableTargetPlayer : ISearchableTarget
    {
        public SearchableTargetPlayer(ITargetPosition position)
        {
            _position = position;
        }
        
        private readonly ITargetPosition _position;
        
        public Vector2 Position => _position.Position;
    }
}