﻿using Cysharp.Threading.Tasks;
using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Local
{
    public interface IMeleeAttack
    {
        UniTask Attack(ISearchableTarget target);
    }
}