using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime
{
    public class BowArrow : IBowArrow, IPlayerSwitchListener
    {
        public BowArrow(SpriteRenderer spriteRenderer, IBowSprite sprite)
        {
            _spriteRenderer = spriteRenderer;
            _sprite = sprite;
        }
        
        private readonly SpriteRenderer _spriteRenderer;
        private readonly IBowSprite _sprite;

        public void OnEnabled()
        {
            _sprite.SortingOrderChanged += OnSortingOrderChanged;
            _sprite.YFlipped += OnYFlipped;
        }

        public void OnDisabled()
        {
            _sprite.SortingOrderChanged -= OnSortingOrderChanged;
            _sprite.YFlipped -= OnYFlipped;
        }
        
        public void Show(Sprite sprite)
        {
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = sprite;
        }

        public void Hide()
        {
            _spriteRenderer.enabled = false;
        }

        private void OnSortingOrderChanged(int order)
        {
            _spriteRenderer.sortingOrder = order + 1;
        }
        
        private void OnYFlipped(bool isFlipped)
        {
            _spriteRenderer.flipY = isFlipped;
        }
    }
}