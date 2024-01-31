using Common.Architecture.Lifetimes.Viewables;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Movement
{
    public interface IMovementInputView
    {
        IViewableDelegate<Vector2> Performed { get; }
        IViewableDelegate Canceled { get; }
    }
}