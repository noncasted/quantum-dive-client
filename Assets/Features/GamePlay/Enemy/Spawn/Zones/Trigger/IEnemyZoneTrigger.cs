using System;

namespace GamePlay.Enemy.Spawn.Zones.Trigger
{
    public interface IEnemyZoneTrigger
    {
        event Action Entered;
    }
}