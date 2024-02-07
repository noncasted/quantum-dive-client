﻿using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Entity.Types.Melee.States.Attack.Local
{
    public interface ITargetChecker
    {
        bool IsAvailable(ISearchableTarget target);
    }
}