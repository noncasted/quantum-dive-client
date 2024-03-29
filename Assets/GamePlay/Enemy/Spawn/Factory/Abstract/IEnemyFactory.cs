﻿using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Factory.Abstract
{
    public interface IEnemyFactory
    {
        UniTask CreateAsync(IEnemyDefinition definition, Vector2 position);
    }
}