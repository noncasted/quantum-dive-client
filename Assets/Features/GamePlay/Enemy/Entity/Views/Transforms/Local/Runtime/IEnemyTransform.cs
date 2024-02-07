﻿using Common.DataTypes.Structs;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime
{
    public interface IEnemyTransform
    {
        Vector2 Position { get; }
        float Rotation { get; }
        Horizontal Look { get; }

        void SetPosition(Vector2 position);
        void SetRotation(float angle);
    }
}