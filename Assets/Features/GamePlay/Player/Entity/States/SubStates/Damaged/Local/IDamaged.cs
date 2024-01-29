using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Local
{
    public interface IDamaged
    {
        void Enter(Vector2 direction, float force);
    }
}