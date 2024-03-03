using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local
{
    public class AimEntry : IFloatingTransition, IUpdatable, IEntitySwitchLifetimeListener
    {
        public AimEntry(
            IAim aim,
            ILocalStateMachine stateMachine,
            IUpdater updater,
            IBowShootInputReceiver inputReceiver,
            IFloatingTransitionsRegistry floatingTransitionsRegistry)
        {
            _aim = aim;
            _stateMachine = stateMachine;
            _updater = updater;
            _inputReceiver = inputReceiver;
            _floatingTransitionsRegistry = floatingTransitionsRegistry;
        }

        private readonly IAim _aim;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IUpdater _updater;
        private readonly IBowShootInputReceiver _inputReceiver;
        private readonly IFloatingTransitionsRegistry _floatingTransitionsRegistry;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _updater.Add(lifetime, this);
            _floatingTransitionsRegistry.Register(lifetime, _aim.Definition, this);
        }
        
        public bool IsTransitionFromFloatingAvailable()
        {
            if (_inputReceiver.IsPerformed == false)
                return false;

            if (_aim.IsEntered == true)
                return false;
            
            return false;
        }
        
        public void EnterFromFloating()
        {
            _aim.Enter();
        }

        public void OnUpdate(float delta)
        {
            if (_inputReceiver.IsPerformed == false)
                return;

            if (_aim.IsEntered == true)
                return;

            if (_stateMachine.IsAvailable(_aim.Definition) == false)
                return;
            
            _aim.Enter();
        }
    }
}