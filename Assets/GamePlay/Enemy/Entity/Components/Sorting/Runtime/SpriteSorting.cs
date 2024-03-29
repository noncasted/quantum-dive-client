﻿using GamePlay.Enemy.Entity.Views.Sprites.Abstract;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Sorting.Runtime
{
    public class SpriteSorting : IEntitySwitchListener, IPostFixedUpdatable
    {
        public SpriteSorting(
            IEnemySpriteLayer layer,
            IEnemyPosition transform,
            IUpdater updater,
            SpriteSortingConfig config)
        {
            _layer = layer;
            _transform = transform;
            _updater = updater;
            _config = config;

            _mask = config.CollisionLayer;
        }

        private readonly IEnemySpriteLayer _layer;
        private readonly IEnemyPosition _transform;
        private readonly IUpdater _updater;
        private readonly SpriteSortingConfig _config;
        private readonly RaycastHit2D[] _buffer = new RaycastHit2D[1];

        private readonly int _mask;

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }

        public void OnPostFixedUpdate(float delta)
        {
            var isTop = IsHit(Vector2.up);

            if (isTop == false)
            {
                _layer.SetLayer(_config.BehindWall);
                return;
            }

            var isBottom = IsHit(Vector2.down);

            if (isBottom == true)
                _layer.SetLayer(_config.BehindWall);
            else
                _layer.SetLayer(_config.FrontWall);
        }

        private bool IsHit(Vector2 direction)
        {
            var hit = Physics2D.RaycastNonAlloc(
                _transform.Position,
                direction,
                _buffer,
                _config.RayDistance,
                _mask);

            if (hit == 0)
                return false;

            return true;
        }
    }
}