using System;
using System.Collections.Generic;
using GamePlay.Enemy.Entity.Views.Sprites.Abstract;
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlay.Enemy.Entity.Views.Sprites.Runtime
{
    public class EnemySprite :
        IEnemySpriteSwitcher,
        IEnemySpriteMaterial,
        IEnemySpriteFlipper,
        IEnemySpriteLayer,
        IEnemySprite
    {
        public EnemySprite(SpriteRenderer sprite, SortingGroup sortingGroup)
        {
            _sprite = sprite;
            _sortingGroup = sortingGroup;
        }

        private readonly SpriteRenderer _sprite;
        private readonly SortingGroup _sortingGroup;

        private readonly List<SpriteRenderer> _subSprites = new();

        public Material Material
        {
            get { return _sprite.material; }
        }

        public event Action<bool> XFlipped;

        public void ResetRotation()
        {
            _sprite.flipX = false;

            foreach (var subSprite in _subSprites)
                subSprite.flipX = false;
        }

        public void SetFlipX(bool isFlipped, bool flipSubSprites)
        {
            _sprite.flipX = isFlipped;

            if (flipSubSprites == true)
                foreach (var subSprite in _subSprites)
                    subSprite.flipX = _sprite.flipX;

            XFlipped?.Invoke(isFlipped);
        }

        public void FlipAlong(Vector2 direction, bool flipSubSprites)
        {
            var isFlipped = direction.x switch
            {
                > 0f => false,
                < 0f => true,
                _ => _sprite.flipX
            };

            SetFlipX(isFlipped, flipSubSprites);
        }

        public void FlipAlong(float angle)
        {
            if (angle is > 90f and < 270f)
                SetFlipX(true, true);
            else
                SetFlipX(false, true);
        }

        public void SetMaterial(Material material)
        {
            _sprite.material = material;
        }

        public void Enable(bool enableSubSprites = false)
        {
            _sprite.enabled = true;

            if (enableSubSprites == true)
                foreach (var subSprite in _subSprites)
                    subSprite.enabled = true;
        }

        public void Disable(bool disableSubSprites = false)
        {
            _sprite.enabled = false;

            if (disableSubSprites == true)
                foreach (var subSprite in _subSprites)
                    subSprite.enabled = false;
        }

        public void AddSubSprite(SpriteRenderer subSprite)
        {
            _subSprites.Add(subSprite);

            subSprite.flipX = _sprite.flipX;
        }

        public void RemoveSubSprite(SpriteRenderer subSprite)
        {
            _subSprites.Remove(subSprite);
        }

        public void SetLayer(string layer)
        {
            _sortingGroup.sortingLayerName = layer;
        }
    }
}