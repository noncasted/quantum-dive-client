using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.States.Abstract
{
    public interface IEnemyRemoteState
    {
        void Enter(RagonBuffer buffer);
        void Break();
    }
}