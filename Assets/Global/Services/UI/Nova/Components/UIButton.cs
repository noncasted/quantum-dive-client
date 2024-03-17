using System;
using Global.UI.Nova.Objects;
using Nova;
using Nova.Events;
using UnityEngine;

namespace Global.UI.Nova.Components
{
    [DisallowMultipleComponent]
    public class UIButton : MonoBehaviour, IEventTarget, IEventTargetProvider
    {
        [SerializeField] private ElementColors _colors;
        [SerializeField] private UIButtonHandler[] _handlers;

        private UIBlock _block;
        private bool _isLocked;
        private bool _isPressed;

        public event Action Clicked;

        public Type BaseTargetableType => typeof(UIButton);
        public bool IsPressed => _isPressed;

        private void Awake()
        {
            _block = GetComponent<UIBlock>();

            if (_colors != null)
                _block.Color = _colors.Idle;
        }

        private void OnEnable()
        {
            _block.RegisterEventTargetProvider(this);

            _block.AddGestureHandler<Gesture.OnClick, UIButton>(HandleClicked);
            _block.AddGestureHandler<Gesture.OnHover, UIButton>(OnHover);
            _block.AddGestureHandler<Gesture.OnUnhover, UIButton>(OnUnhover);
            _block.AddGestureHandler<Gesture.OnPress, UIButton>(OnPress);
            _block.AddGestureHandler<Gesture.OnRelease, UIButton>(OnRelease);
            _block.AddGestureHandler<Gesture.OnCancel, UIButton>(OnCancel);
        }

        private void OnDisable()
        {
            _block.RemoveGestureHandler<Gesture.OnClick, UIButton>(HandleClicked);
            _block.RemoveGestureHandler<Gesture.OnHover, UIButton>(OnHover);
            _block.RemoveGestureHandler<Gesture.OnUnhover, UIButton>(OnUnhover);
            _block.RemoveGestureHandler<Gesture.OnPress, UIButton>(OnPress);
            _block.RemoveGestureHandler<Gesture.OnRelease, UIButton>(OnRelease);
            _block.RemoveGestureHandler<Gesture.OnCancel, UIButton>(OnCancel);
        }

        public void ClearListeners()
        {
            Clicked = null;
        }

        public void Lock()
        {
            _isLocked = true;
        }

        public void Unlock()
        {
            _isLocked = false;
        }

        public void Clear()
        {
            if (_colors != null)
                _block.Color = _colors.Idle;
        }

        private void OnHover(Gesture.OnHover data, UIButton visuals)
        {
            if (_isLocked == true)
                return;

            if (_colors != null)
                _block.Color = _colors.Hovered;

            foreach (var handler in _handlers)
                handler.OnHover();
        }

        private void OnUnhover(Gesture.OnUnhover data, UIButton visuals)
        {
            if (_isLocked == true)
                return;

            if (_colors != null)
                _block.Color = _colors.Idle;

            foreach (var handler in _handlers)
                handler.OnUnhover();
        }

        private void OnPress(Gesture.OnPress data, UIButton visuals)
        {
            if (_isLocked == true)
                return;

            if (_colors != null)
                _block.Color = _colors.Pressed;

            _isPressed = true;

            foreach (var handler in _handlers)
                handler.OnPress();
        }

        private void OnRelease(Gesture.OnRelease data, UIButton visuals)
        {
            if (_isLocked == true)
                return;

            if (_colors != null)
                _block.Color = _colors.Hovered;

            _isPressed = false;
            
            foreach (var handler in _handlers)
                handler.OnRelease();
        }

        private void OnCancel(Gesture.OnCancel data, UIButton visuals)
        {
            if (_isLocked == true)
                return;

            if (_colors != null)
                _block.Color = _colors.Idle;

            _isPressed = false;

            foreach (var handler in _handlers)
                handler.OnCancel();
        }

        private void HandleClicked(Gesture.OnClick data, UIButton visuals)
        {
            if (_isLocked == true)
                return;

            Clicked?.Invoke();
        }

        public bool TryGetTarget(IEventTarget eventReceiver, Type eventType, out IEventTarget eventTarget)
        {
            eventTarget = this;
            return true;
        }
    }
}