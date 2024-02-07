using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Runtime
{
    public interface IEnemySprite
    {
        void AddSubSprite(SpriteRenderer subSprite);
        void RemoveSubSprite(SpriteRenderer subSprite);
    }
}