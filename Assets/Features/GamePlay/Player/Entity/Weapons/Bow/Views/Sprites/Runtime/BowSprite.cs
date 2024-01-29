using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime
{
    public class BowSprite :  IBowSprite
    {
        public BowSprite(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }
        
        private readonly SpriteRenderer _spriteRenderer;

        public event Action<bool> YFlipped;
        public event Action<int> SortingOrderChanged;

        public void SetSortingOrder(int order)
        {
            _spriteRenderer.sortingOrder = order;
            
            SortingOrderChanged?.Invoke(order);
        }

        public void FlipY(bool isFlipped)
        {
            _spriteRenderer.flipY = isFlipped;
        }

        public void FlipX(bool isFlipped)
        {
            _spriteRenderer.flipX = isFlipped;
            
            YFlipped?.Invoke(isFlipped);
        }
    }
}