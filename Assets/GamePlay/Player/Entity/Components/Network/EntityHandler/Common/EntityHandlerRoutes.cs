﻿using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Components.Network.Common;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Common
{
    public class EntityHandlerRoutes
    {
        private const string Paths = PlayerNetworkRoutes.Root;

        public const string ServicePath = Paths + "/EntityHandler";
        public const string ServiceName = PlayerEntityPrefixes.Component + "EntityHandler";
    }
}