using System;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Abstract
{
    public interface IEnemySpriteFlipper
    {
        event Action<bool> XFlipped;

        void ResetRotation();
        void SetFlipX(bool isFlipped, bool flipSubSprites);
        void FlipAlong(Vector2 direction, bool flipSubSprites);
        void FlipAlong(float angle);
    }
}