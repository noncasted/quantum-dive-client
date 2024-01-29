using GamePlay.Enemies.Entity.Views.Hitbox.Local;
using GamePlay.Enemies.Types.Melee.States.Attack.Common.Config;
using Global.Debugs.Drawing.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Debug
{
    public class GizmosDrawer : IMeleeAttackGizmosDrawer, IGizmosUpdatable
    {
        public GizmosDrawer(
            IShapeDrawer shapeDrawer,
            IUpdater updater,
            IMeleeAttackGizmosConfig gizmosConfig,
            IMeleeAttackConfig attackConfig,
            IHitbox hitbox)
        {
            _shapeDrawer = shapeDrawer;
            _updater = updater;
            _gizmosConfig = gizmosConfig;
            _attackConfig = attackConfig;
            _hitbox = hitbox;
        }

        private readonly IShapeDrawer _shapeDrawer;
        private readonly IUpdater _updater;

        private readonly IMeleeAttackGizmosConfig _gizmosConfig;
        private readonly IMeleeAttackConfig _attackConfig;
        private readonly IHitbox _hitbox;

        public void Enable()
        {
            _updater.Add(this);
        }

        public void Disable()
        {
            _updater.Remove(this);
        }

        public void OnGizmosUpdate()
        {

        }
    }
}