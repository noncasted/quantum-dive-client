using System;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Abstract
{
    public static class InputExtensions
    {
        public static void Listen(
            this InputAction action,
            IReadOnlyLifetime lifetime,
            Action<InputAction.CallbackContext> performed,
            Action<InputAction.CallbackContext> canceled)
        {
            action.performed += performed;
            action.canceled += canceled;
            
            lifetime.ListenTerminate(() =>
            {
                action.performed -= performed;
                action.canceled -= canceled;
            });
        }
    }
}