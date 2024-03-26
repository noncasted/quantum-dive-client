using System;
using System.Threading;
using Common.DataTypes.Runtime.Structs;
using Cysharp.Threading.Tasks;
using Global.Cameras.Utils.Abstract;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Implementations.Mouses.Abstract;
using Global.System.Updaters.Abstract;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Mouses.Runtime
{
    public class MouseInput : IInputConstructListener, IUpdatable, IMouseInput
    {
        public MouseInput(
            IInputConstraintsStorage constraintsStorage,
            IUpdater updater,
            ICameraUtils cameraUtils,
            Controls.GamePlayActions gamePlay)
        {
            _constraintsStorage = constraintsStorage;
            _updater = updater;
            _cameraUtils = cameraUtils;
            _gamePlay = gamePlay;
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly IUpdater _updater;
        private readonly ICameraUtils _cameraUtils;
        private readonly Controls.GamePlayActions _gamePlay;

        private bool _isWheelPressed;

        public event Action LeftDown;
        public event Action LeftUp;
        public event Action RightDown;
        public event Action RightUp;
        public event Action<Vertical> Scroll;

        public Vector2 Position { get; private set; }
        public bool IsWheelPressed => _isWheelPressed;

        public void OnInputConstructed(IReadOnlyLifetime lifetime)
        {
            _gamePlay.LeftClick.Listen(lifetime, OnLeftMouseButtonDown, OnLeftMouseButtonUp);
            _gamePlay.RightClick.Listen(lifetime, OnRightMouseButtonDown, OnRightMouseButtonUp);
            _gamePlay.MouseWheel.Listen(lifetime, OnMouseWheelDown, OnMouseWheelUp);
            _gamePlay.Scroll.Listen(lifetime, OnScrollPerformed, OnScrollCanceled);

            _updater.Add(this);
        }

        public void Listen()
        {
            _gamePlay.LeftClick.performed += OnLeftMouseButtonDown;
            _gamePlay.LeftClick.canceled += OnLeftMouseButtonUp;

            _gamePlay.RightClick.performed += OnRightMouseButtonDown;
            _gamePlay.RightClick.canceled += OnRightMouseButtonUp;

            _gamePlay.MouseWheel.performed += OnMouseWheelDown;
            _gamePlay.MouseWheel.canceled += OnMouseWheelUp;

            _gamePlay.Scroll.performed += OnScrollPerformed;
        }

        public void Dispose()
        {
            _gamePlay.LeftClick.performed -= OnLeftMouseButtonDown;
            _gamePlay.LeftClick.canceled -= OnLeftMouseButtonUp;
            _gamePlay.RightClick.performed -= OnRightMouseButtonDown;
            _gamePlay.RightClick.canceled -= OnRightMouseButtonUp;

            _gamePlay.MouseWheel.performed += OnMouseWheelDown;
            _gamePlay.MouseWheel.canceled += OnMouseWheelUp;

            _gamePlay.Scroll.performed += OnScrollPerformed;

            _updater.Remove(this);
        }

        public async UniTask WaitLeftDownAsync(CancellationToken cancellation)
        {
            var completion = new UniTaskCompletionSource();

            cancellation.Register(() =>
            {
                completion.TrySetCanceled();
                LeftDown -= OnDown;
            });

            LeftDown += OnDown;

            void OnDown()
            {
                completion.TrySetResult();
                LeftDown -= OnDown;
            }

            await completion.Task;
        }

        public Vector2 GetWorldPoint()
        {
            return _cameraUtils.ScreenToWorld(Position);
        }

        private void OnLeftMouseButtonDown(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
                return;

            LeftDown?.Invoke();
        }

        private void OnLeftMouseButtonUp(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
                return;

            LeftUp?.Invoke();
        }

        private void OnRightMouseButtonDown(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
                return;

            RightDown?.Invoke();
        }

        private void OnRightMouseButtonUp(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
                return;

            RightUp?.Invoke();
        }


        private void OnScrollPerformed(InputAction.CallbackContext context)
        {
            var scroll = context.ReadValue<float>();

            if (scroll > 0f)
                Scroll?.Invoke(Vertical.Up);
            else
                Scroll?.Invoke(Vertical.Down);
        }

        private void OnScrollCanceled(InputAction.CallbackContext context)
        {
        }

        private void OnMouseWheelDown(InputAction.CallbackContext context)
        {
            _isWheelPressed = true;
        }

        private void OnMouseWheelUp(InputAction.CallbackContext context)
        {
            _isWheelPressed = false;
        }

        public void OnUpdate(float delta)
        {
            if (Application.isMobilePlatform == true)
            {
                var touches = Input.touches;
                _isWheelPressed = false;

                if (touches.Length < 1)
                    return;

                Position = touches[0].rawPosition;
                _isWheelPressed = true;
                LeftDown?.Invoke();
            }
            else
            {
                Position = Mouse.current.position.ReadValue();
            }
        }
    }
}