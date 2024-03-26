using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Abstract;
using Global.System.Updaters.Abstract;
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
            IEntityProvider entityProvider) : base(0, false)
        {
            _transform = transform;
            _updater = updater;
            _entityProvider = entityProvider;
        }

        private readonly IPlayerTransform _transform;
        private readonly IUpdater _updater;
        private readonly IEntityProvider _entityProvider;

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

        }

        public override void Deserialize(RagonBuffer buffer)
        {

        }
    }
}