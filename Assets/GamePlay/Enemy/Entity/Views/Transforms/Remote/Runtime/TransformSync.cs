using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.DataTypes.Network;
using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Logs;
using Global.System.Updaters.Runtime.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.Views.Transforms.Remote.Runtime
{
    public class TransformSync : RagonProperty, IEntitySwitchListener, IFixedUpdatable
    {
        protected TransformSync(
            IEnemyTransform transform,
            IUpdater updater,
            IEntityProvider entityProvider,
            TransformSyncLogger logger) : base(0, false)
        {
            _transform = transform;
            _updater = updater;
            _entityProvider = entityProvider;
            _logger = logger;

            SetFixedSize(RagonBufferExtensions.GetVectorRequiredBits());
        }

        private readonly IEnemyTransform _transform;
        private readonly IUpdater _updater;
        private readonly IEntityProvider _entityProvider;
        private readonly TransformSyncLogger _logger;

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
            _logger.OnSerialize(_transform.Position);

            buffer.WriteVector(_transform.Position);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var position = buffer.ReadVector();

            if (_entityProvider.IsMine == true)
                return;

            _logger.OnDeserialize(_transform.Position);

            _transform.SetPosition(position);
        }
    }
}