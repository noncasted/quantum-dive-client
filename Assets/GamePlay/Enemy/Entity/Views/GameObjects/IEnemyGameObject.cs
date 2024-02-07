﻿namespace GamePlay.Enemy.Entity.Views.GameObjects
{
    public interface IEnemyGameObject
    {
        string Name { get; }

        void Enable();
        void Disable();
    }
}