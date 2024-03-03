using UnityEngine;

namespace GamePlay.Combat.Targets.Registry.Runtime
{
    public class SearchableTargetPlayer : ISearchableTarget
    {
        public SearchableTargetPlayer(ITargetPosition position)
        {
            _position = position;
        }
        
        private readonly ITargetPosition _position;
        
        public Vector3 Position => _position.Position;
    }
}