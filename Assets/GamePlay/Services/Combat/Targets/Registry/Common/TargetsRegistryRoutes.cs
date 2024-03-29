﻿using GamePlay.Services.Common.Routes;

namespace GamePlay.Services.Targets.Registry.Common
{
    public class TargetsRegistryRoutes
    {
        public const string ServiceName = GamePlayServicesPrefixes.Service + "TargetRegistry";
        public const string ServicePath = GamePlayServicesRoutes.Root + "TargetsRegistry/Serivce";
        
        public const string ConfigName = GamePlayServicesPrefixes.Config + "TargetRegistry";
        public const string ConfigPath = GamePlayServicesRoutes.Root + "TargetsRegistry/Config";
    }
}