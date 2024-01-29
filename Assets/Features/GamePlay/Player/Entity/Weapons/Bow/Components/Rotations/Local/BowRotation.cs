using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Common;
using GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime;
using Global.Inputs.Utils.Runtime.Projection;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Local
{
    public class BowRotation : IPlayerSwitchListener, IUpdatable, IBowRotation
    {
        public BowRotation(
            IBowTransform transform,            
            IBowPivotsProvider bowPivotsProvider,
            IInputProjection inputProjection,
            IUpdater updater,
            IBowSprite sprite,
            IRotation rotation,
            RotationConfigAsset config)
        {
            _transform = transform;
            _bowPivotsProvider = bowPivotsProvider;
            _inputProjection = inputProjection;
            _updater = updater;
            _sprite = sprite;
            _rotation = rotation;
            _config = config;
        }

        private readonly RotationConfigAsset _config;
        private readonly IInputProjection _inputProjection;
        private readonly IBowTransform _transform;
        private readonly IBowPivotsProvider _bowPivotsProvider;
        private readonly IRotation _rotation;
        private readonly IBowSprite _sprite;
        private readonly IUpdater _updater;

        private float _angle;

        public float Angle => _angle;

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
            _angle = _inputProjection.GetAngleFrom(center);
            var direction = _angle.ToDirection();

            var position = center + direction * _config.Distance;

            _transform.SetPosition(position);
            _transform.SetRotation(_angle);

            if (_rotation.Angle is > 22.5f and < 157.45f)
                _sprite.SetSortingOrder(-2);
            else
                _sprite.SetSortingOrder(1);

            if (_angle < 90f || _angle > 270f)
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