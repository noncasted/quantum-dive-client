﻿namespace GamePlay.Enemy.Entity.Common.Definition.Config
{
    public interface IRemoteEnemyConfig : IEnemyConfig
    {
        EnemyViewFactory Prefab { get; }
    }
}