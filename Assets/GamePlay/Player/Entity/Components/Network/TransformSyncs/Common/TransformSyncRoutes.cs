﻿using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Network.Common;

namespace GamePlay.Player.Entity.Components.Network.TransformSyncs.Common
{
    public class TransformSyncRoutes
    {
        public const string ServiceName = PlayerEntityPrefixes.Component + "Network_Transform";
        public const string ServicePath = PlayerNetworkRoutes.Root + "Transform/Component";
        
        public const string LogsName = PlayerEntityPrefixes.Logs + "Network_Transform";
        public const string LogsPath = PlayerNetworkRoutes.Root + "Transform/Logs";
    }
}