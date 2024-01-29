﻿using GamePlay.Enemies.Services.Paths;

namespace GamePlay.Enemies.Services.Spawn.Factory.Common
{
    public class EnemyFactoryRoutes
    {
        public const string ServiceName = EnemyServicesAssetsPrefixes.Service + "Factory";
        public const string ServicePath = EnemyServicesAssetsPaths.Root + "Factory/Service";
        
        public const string LogsName = EnemyServicesAssetsPrefixes.Logs + "Factory";
        public const string LogsPath = EnemyServicesAssetsPaths.Root + "Factory/Logs";
    }
}