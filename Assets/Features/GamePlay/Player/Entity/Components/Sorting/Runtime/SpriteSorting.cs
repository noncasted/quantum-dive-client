using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Sorting.Runtime
{
    public class SpriteSorting : IPlayerSwitchListener, IPostFixedUpdatable
    {
        public SpriteSorting(
            IPlayerSpriteLayer layer,
            IPlayerTransform transform,
            IUpdater updater,
            SpriteSortingConfig config)
        {
            _layer = layer;
            _transform = transform;
            _updater = updater;
            _config = config;

            _mask = config.CollisionLayer;
        }

        private readonly IPlayerSpriteLayer _layer;
        private readonly IPlayerTransform _transform;
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