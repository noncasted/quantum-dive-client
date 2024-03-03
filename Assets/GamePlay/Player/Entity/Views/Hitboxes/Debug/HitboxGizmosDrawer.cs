using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using GamePlay.Player.Entity.Views.Hitboxes.Common;
using Global.Debugs.Drawing.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Hitboxes.Debug
{
    public class HitboxGizmosDrawer : IEntitySwitchLifetimeListener, IGizmosUpdatable
    {
        public HitboxGizmosDrawer(
            IShapeDrawer shapeDrawer,
            IUpdater updater,
            IHitboxGizmosConfig gizmosConfig,
            IHitboxConfig hitboxConfig,
            Transform point)
        {
            _shapeDrawer = shapeDrawer;
            _updater = updater;
            _gizmosConfig = gizmosConfig;
            _hitboxConfig = hitboxConfig;
            _point = point;
        }

        private readonly IShapeDrawer _shapeDrawer;
        private readonly IUpdater _updater;

        private readonly IHitboxGizmosConfig _gizmosConfig;
        private readonly IHitboxConfig _hitboxConfig;
        private readonly Transform _point;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
        }

        public void OnGizmosUpdate()
        {
            _shapeDrawer.DrawCircle(
                _point.position,
                _hitboxConfig.Radius,
                _gizmosConfig.Width,
                _gizmosConfig.Color);
        }
    }
}