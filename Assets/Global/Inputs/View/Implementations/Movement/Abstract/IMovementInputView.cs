using Common.DataTypes.Runtime.Reactive;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Movement.Abstract
{
    public interface IMovementInputView
    {
        IViewableDelegate<Vector2> Performed { get; }
        IViewableDelegate Canceled { get; }
    }
}
