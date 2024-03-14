using Global.Debugs.Drawing.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Common
{
    public class GizmosDrawer : IEntitySwitchListener, IGizmosUpdatable
    {
        public GizmosDrawer(
            IShapeDrawer shapeDrawer,
            IUpdater updater,
            IGizmosConfig gizmosConfig,
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
        
        private readonly IGizmosConfig _gizmosConfig;
        private readonly IHitboxConfig _hitboxConfig;
        private readonly Transform _point;

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
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