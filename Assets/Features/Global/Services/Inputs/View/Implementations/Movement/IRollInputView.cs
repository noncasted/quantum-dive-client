using System;

namespace Global.Inputs.View.Implementations.Movement
{
    public interface IRollInputView
    {
        event Action Performed;
        event Action Canceled;
    }
}