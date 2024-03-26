using GamePlay.Player.Entity.Components.Rotations.Local.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Abstract;
using GamePlay.Player.Entity.Views.RotationPoint.Abstract;
using Global.Inputs.Utils.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Runtime
{
    public class LocalRotation : IPreUpdatable, IRotation, IEntitySwitchLifetimeListener
    {
        public LocalRotation(
            IInputProjection inputProjection,
            IUpdater updater,
            IPlayerRotationPoint point,
            IRotationSync sync)
        {
            _inputProjection = inputProjection;
            _updater = updater;
            _point = point;
            _sync = sync;
        }

        private readonly IInputProjection _inputProjection;
        private readonly IPlayerRotationPoint _point;
        private readonly IRotationSync _sync;
        private readonly IUpdater _updater;

        private float _angle;

        public float Angle
        {
            get
            {
               return _angle;
            }
        }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
        }

        public void OnPreUpdate(float delta = 0f)
        {
            _angle = _inputProjection.GetAngleFrom(_point.Position);
            _sync.SetRotation(_angle);
        }
    }
}