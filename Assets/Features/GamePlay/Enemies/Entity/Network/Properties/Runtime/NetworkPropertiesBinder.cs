using Common.Architecture.Entities.Common.DefaultCallbacks;
using GamePlay.Enemies.Entity.Components.Health.Runtime;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Enemies.Entity.Network.EntityHandler.Runtime;
using GamePlay.Enemies.Entity.Views.Hitbox.Common;
using GamePlay.Enemies.Entity.Views.Transforms.Remote.Runtime;

namespace GamePlay.Enemies.Entity.Network.Properties.Runtime
{
    public class NetworkPropertiesBinder : IEntityEnableListener
    {
        public NetworkPropertiesBinder(
            IPropertyBinder propertyBinder,
            TransformSync transform,
            RemoteStateMachine stateMachine,
            HitboxStateSync hitboxState,
            Health health)
        {
            _propertyBinder = propertyBinder;
            _transform = transform;
            _stateMachine = stateMachine;
            _hitboxState = hitboxState;
            _health = health;
        }
        
        
        private readonly IPropertyBinder _propertyBinder;
        private readonly TransformSync _transform;
        private readonly RemoteStateMachine _stateMachine;
        private readonly HitboxStateSync _hitboxState;
        private readonly Health _health;

        public void OnEnabled()
        {
            _propertyBinder.BindProperty(_transform);
            _propertyBinder.BindProperty(_stateMachine);
            _propertyBinder.BindProperty(_hitboxState);
            _propertyBinder.BindProperty(_health);
        }
    }
}