﻿using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Views.RigidBodies.Common
{
    public class RigidBodyRoutes
    {
        private const string _root = EnemyAssetsPaths.Views + _name;
        private const string _name = "RigidBody";

        public const string LogsName = EnemyAssetsPrefixes.Logs + _name;
        public const string LogsPath = _root + "/Logs";
    }
}