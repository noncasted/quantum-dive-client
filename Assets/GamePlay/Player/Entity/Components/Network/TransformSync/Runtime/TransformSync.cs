using Common.DataTypes.Network;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Components.Network.TransformSync.Logs;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Network.TransformSync.Runtime
{
    public class TransformSync : RagonProperty, IEntitySwitchLifetimeListener, IFixedUpdatable
    {
        protected TransformSync(
            IPlayerTransform transform,
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

        private readonly IPlayerTransform _transform;
        private readonly IUpdater _updater;
        private readonly IEntityProvider _entityProvider;
        private readonly TransformSyncLogger _logger;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
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