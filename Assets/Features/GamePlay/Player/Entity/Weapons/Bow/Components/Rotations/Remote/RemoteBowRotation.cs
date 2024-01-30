using Common.Architecture.Entities.Runtime.Callbacks;
using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;

using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Remote
{
    public class RemoteBowRotation : IEntitySwitchListener, IUpdatable
    {
        public RemoteBowRotation(
            IBowTransform transform,            
            IBowPivotsProvider bowPivotsProvider,
            IUpdater updater,
            IBowSprite sprite,
            IRemoteRotation rotation,
            RotationConfigAsset config)
        {
            _transform = transform;
            _bowPivotsProvider = bowPivotsProvider;
            _updater = updater;
            _sprite = sprite;
            _rotation = rotation;
            _config = config;
        }

        private readonly RotationConfigAsset _config;
        private readonly IBowTransform _transform;
        private readonly IBowPivotsProvider _bowPivotsProvider;
        private readonly IRemoteRotation _rotation;
        private readonly IBowSprite _sprite;
        private readonly IUpdater _updater;

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }

        public void OnUpdate(float delta)
        {
            var center = _bowPivotsProvider.GetPosition(_rotation.Side, _rotation.Orientation);
            var angle = _rotation.Angle;
            var direction = angle.ToDirection();

            var position = center + direction * _config.Distance;

            _transform.SetPosition(position);
            _transform.SetRotation(angle);

            if (_rotation.Angle is > 22.5f and < 157.45f)
                _sprite.SetSortingOrder(-2);
            else
                _sprite.SetSortingOrder(1);

            if (angle < 90f || angle > 270f)
            {
                _sprite.FlipY(false);
                _sprite.FlipX(false);
            }
            else
            {
                _sprite.FlipY(true);
                _sprite.FlipX(false);
            }
        }
    }
}