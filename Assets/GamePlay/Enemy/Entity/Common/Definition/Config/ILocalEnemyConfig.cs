﻿namespace GamePlay.Enemy.Entity.Common.Definition.Config
{
    public interface ILocalEnemyConfig : IEnemyConfig
    {
        EnemyViewFactory Prefab { get; }
    }
}