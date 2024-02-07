﻿using GamePlay.Common.Routes;

namespace GamePlay.Ecs.Common
{
    public static class EcsRoutes
    {
        public const string ServicePath = GamePlayServicesRoutes.Root + "ECS/Service";
        public const string ServiceName = GamePlayServicesPrefixes.Service + "Ecs";
    }
}