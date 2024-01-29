using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Sprites.Runtime
{
    public interface IPlayerSpriteFlip
    {
        event Action<bool> XFlipped;

        void ResetRotation();
        void SetFlipX(bool isFlipped, bool flipSubSprites);
        void FlipAlong(Vector2 direction, bool flipSubSprites);
        void FlipAlong(float angle);
    }
}