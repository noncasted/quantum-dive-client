using GamePlay.Enemy.Spawn.Zones.Abstract;

namespace GamePlay.Enemy.Spawn.Zones.Runtime
{
    public readonly struct ZoneActivationRequest
    {
        public ZoneActivationRequest(IEnemyZone zone)
        {
            Zone = zone;
        }
        
        public readonly IEnemyZone Zone;
    }
}