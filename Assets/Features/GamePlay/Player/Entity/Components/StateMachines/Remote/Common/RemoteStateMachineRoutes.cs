﻿using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Common
{
    public class RemoteStateMachineRoutes
    {
        public const string ServiceName = PlayerEntityPrefixes.Component + "StateMachine_Remote";
        public const string ServicePath = PlayerComponentsRoutes.Root + "StateMachine/Remote/Component";
        
        public const string LogsName = PlayerEntityPrefixes.Logs + "StateMachine_Remote";
        public const string LogsPath = PlayerComponentsRoutes.Root + "StateMachine/Remote/Logs";
    }
}