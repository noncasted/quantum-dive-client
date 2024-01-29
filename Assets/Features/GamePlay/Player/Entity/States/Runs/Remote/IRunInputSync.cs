using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Remote
{
    public interface IRunInputSync
    {
        float Angle { get; }
        PlayerOrientation Orientation { get; }
        
        void OnInput(Vector2 input);
    }
}