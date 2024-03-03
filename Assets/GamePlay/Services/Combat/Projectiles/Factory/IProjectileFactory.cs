using System;

namespace GamePlay.Combat.Projectiles.Factory
{
    public interface IProjectileFactory
    {
        event Action<ProjectileRequest> PlayerProjectileCreated; 
        event Action<ProjectileRequest> EnemyProjectileCreated; 

        void CreateLocalPlayer(ProjectileRequest request);
        
        void CreateRemotePlayer(ProjectileRequest request);

        void CreateLocalEnemy(ProjectileRequest request);
        
        void CreateRemoteEnemy(ProjectileRequest request);
    }
}