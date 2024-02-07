using System;

namespace GamePlay.Enemy.Entity.States.Death.Local
{
    public interface IDeath
    {
        event Action Died;
        
        void Enter();
    }
}