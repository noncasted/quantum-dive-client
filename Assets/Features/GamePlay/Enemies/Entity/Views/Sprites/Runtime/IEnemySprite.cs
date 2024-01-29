using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Sprites.Runtime
{
    public interface IEnemySprite
    {
        void AddSubSprite(SpriteRenderer subSprite);
        void RemoveSubSprite(SpriteRenderer subSprite);
    }
}