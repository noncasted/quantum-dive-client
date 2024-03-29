﻿using GamePlay.Player.Entity.Components.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Player.Entity.Components.Network.TransformSyncs.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using GamePlay.Player.Entity.States.Runs.Remote;

namespace GamePlay.Player.Entity.Components.Network.Properties.Runtime
{
    public class NetworkPropertiesInjector
    {
        public NetworkPropertiesInjector(
            IPropertyBinder propertyBinder,
            TransformSync transform,
            RotationSync rotation,
            RunInputSync runInput,
            RemoteStateMachine stateMachine,
            RemoteEquipper equipper
        )
        {
            propertyBinder.BindProperty(transform);
            propertyBinder.BindProperty(rotation);
            propertyBinder.BindProperty(runInput);
            propertyBinder.BindProperty(stateMachine);
            propertyBinder.BindProperty(equipper);
        }
    }
}