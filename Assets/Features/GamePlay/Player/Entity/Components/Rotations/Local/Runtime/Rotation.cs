using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime.Callbacks;
using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Local.Logs;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Views.RotationPoint.Runtime;
using Global.Inputs.Utils.Runtime.Projection;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Runtime
{
    public class Rotation : IPreUpdatable, IRotation, IEntitySwitchListener
    {
        public Rotation(
            IInputProjection inputProjection,
            IUpdater updater,
            IPlayerRotationPoint point,
            IRotationSync sync,
            LocalRotationLogger logger)
        {
            _inputProjection = inputProjection;
            _updater = updater;
            _point = point;
            _sync = sync;
            _logger = logger;
        }

        private readonly IInputProjection _inputProjection;
        private readonly LocalRotationLogger _logger;
        private readonly IPlayerRotationPoint _point;
        private readonly IRotationSync _sync;
        private readonly IUpdater _updater;

        private float _angle;
        private Horizontal _side;
        private PlayerOrientation _orientation;
        
        public float Angle
        {
            get
            {
                _logger.OnRotationUsed(_angle);

                return _angle;
            }
        }

        public Horizontal Side => _side;
        public PlayerOrientation Orientation => _orientation;

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }

        public void OnPreUpdate(float delta = 0f)
        {
            _angle = _inputProjection.GetAngleFrom(_point.Position);
            _side = _angle.ToHorizontal();
            _orientation = _angle.ToOrientation();

            _logger.OnRotationSet(_angle);
            
            _sync.SetRotation(_angle);
        }
    }
}