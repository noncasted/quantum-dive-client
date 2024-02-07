using System;

namespace GamePlay.Enemies.Entity.States.Death.Local
{
    public interface IDeath
    {
        event Action Died;
        
        void Enter();
    }
}