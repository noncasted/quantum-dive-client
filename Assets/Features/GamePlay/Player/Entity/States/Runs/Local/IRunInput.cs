using System;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    public interface IRunInput
    {
        event Action Performed;
        event Action Canceled;
        
        Vector2 Direction { get; }
        bool HasInput { get; }
    }
}