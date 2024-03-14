using UnityEngine;

namespace GamePlay.Services.Combat.Targets.Registry.Abstract
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