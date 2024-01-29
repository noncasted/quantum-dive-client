using System;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Movement
{
    public interface IMovementInputView
    {
        event Action<Vector2> MovementPerformed;
        event Action MovementCanceled;
    }
}