using System;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    public interface IRollInput
    {
        event Action Performed;

        Vector2 Direction { get; }
        bool HasInput { get; }
    }
}