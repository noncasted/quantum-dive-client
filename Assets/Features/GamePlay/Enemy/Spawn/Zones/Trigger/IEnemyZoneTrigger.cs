using System;

namespace GamePlay.Enemies.Spawn.Zones.Trigger
{
    public interface IEnemyZoneTrigger
    {
        event Action Entered;
    }
}