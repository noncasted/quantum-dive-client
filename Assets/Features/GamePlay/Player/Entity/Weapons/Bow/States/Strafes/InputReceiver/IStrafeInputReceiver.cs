using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver
{
    public interface IStrafeInputReceiver
    {
        bool IsPerformed { get; }
        Vector2 Direction { get; }
    }
}