using Common.Architecture.Lifetimes.Viewables;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    public interface IRollInput
    {
        IViewableDelegate Performed { get; }

        Vector2 Direction { get; }
        bool HasInput { get; }
    }
}