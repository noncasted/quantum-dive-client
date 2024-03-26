using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.Views.Transforms.Remote.Runtime
{
    public class TransformSync : RagonProperty, IEntitySwitchListener, IFixedUpdatable
    {
        protected TransformSync(
            IEnemyTransform transform,
            IUpdater updater,
            IEntityProvider entityProvider) : base(0, false)
        {
            _transform = transform;
            _updater = updater;
            _entityProvider = entityProvider;
        }

        private readonly IEnemyTransform _transform;
        private readonly IUpdater _updater;
        private readonly IEntityProvider _entityProvider;

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }

        public void OnFixedUpdate(float delta)
        {
            MarkAsChanged();
        }

        public override void Serialize(RagonBuffer buffer)
        {
         }

        public override void Deserialize(RagonBuffer buffer)
        {
        }
    }
}