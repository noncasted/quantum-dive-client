using UnityEngine;

namespace GamePlay.Player.Entity.Views.Sprites.Runtime
{
    public interface IPlayerSprite
    {
        void AddSubSprite(SpriteRenderer subSprite);
        void RemoveSubSprite(SpriteRenderer subSprite);
    }
}