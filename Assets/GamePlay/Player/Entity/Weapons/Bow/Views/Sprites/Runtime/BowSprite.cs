using Common.Architecture.Lifetimes.Viewables;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime
{
    public class BowSprite : IBowSprite
    {
        public BowSprite(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        private readonly SpriteRenderer _spriteRenderer;

        private readonly IViewableDelegate<bool> _yFlipped = new ViewableDelegate<bool>();
        private readonly IViewableDelegate<int> _sortingOrderChanged = new ViewableDelegate<int>();

        public IViewableDelegate<bool> YFlipped => _yFlipped;
        public IViewableDelegate<int> SortingOrderChanged => _sortingOrderChanged;

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