using Ragon.Protocol;

namespace GamePlay.Enemies.Entity.States.Abstract
{
    public interface IEnemyRemoteState
    {
        void Enter(RagonBuffer buffer);
        void Break();
    }
}