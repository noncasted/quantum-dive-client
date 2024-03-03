using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Remote
{
    public interface IRunInputSync
    {
        float Angle { get; }
        
        void OnInput(Vector2 input);
    }
}