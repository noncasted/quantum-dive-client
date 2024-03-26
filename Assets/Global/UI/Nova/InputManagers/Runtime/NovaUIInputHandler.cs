using Global.System.Updaters.Abstract;
using Global.UI.Nova.InputManagers.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Global.UI.Nova.InputManagers.Runtime
{
    public class NovaUIInputHandler : IUIInputHandler, IUICameraProvider, IScopeSwitchListener, IPreUpdatable
    {
        public NovaUIInputHandler(IUpdater updater)
        {
            _updater = updater;
            _mouseInputHandler = new MouseInputHandler(this);
            _touchInputHandler = new TouchInputHandler(this);
        }

        private readonly IUpdater _updater;
        private readonly MouseInputHandler _mouseInputHandler;
        private readonly TouchInputHandler _touchInputHandler;

        private Camera _currentCamera;

        public Camera CurrentCamera => _currentCamera;

        public void OnEnabled()
        {
            if (Touchscreen.current != null)
                EnhancedTouchSupport.Enable();

            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }

        public void SetCamera(Camera camera)
        {
            _currentCamera = camera;
        }

        public void RemoveCamera(Camera camera)
        {
            if (_currentCamera != camera)
                return;

            _currentCamera = null;
        }

        public bool IsCollidingLayer(int layerMask)
        {
            return _mouseInputHandler.IsCollidingLayer(layerMask);
        }

        public void OnPreUpdate(float delta)
        {
            if (_currentCamera == null)
                return;

            if (Mouse.current != null)
                _mouseInputHandler.UpdateMouse();

            if (Touchscreen.current != null)
                _touchInputHandler.UpdateTouch();
        }
    }
}