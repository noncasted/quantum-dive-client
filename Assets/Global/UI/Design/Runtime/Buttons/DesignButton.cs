using System;
using Common.Components.Runtime.ObjectLifetime;
using Common.DataTypes.Runtime.Reactive;
using Global.UI.Design.Abstract.Buttons;
using Nova;
using Nova.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Design.Runtime.Buttons
{
    public class DesignButton :
        MonoBehaviour,
        IDesignButton,
        IEventTarget,
        IEventTargetProvider
    {
        [SerializeField] private DesignButtonBehaviour[] _behaviours;

        private readonly ViewableDelegate _clicked = new();
        private readonly ViewableProperty<DesignButtonState> _state = new(DesignButtonState.Idle);

        private UIBlock _block;
        private bool _isLocked;

        public IViewableDelegate Clicked => _clicked;
        public IViewableProperty<DesignButtonState> State => _state;

        public Type BaseTargetableType => typeof(DesignButton);

        private void Awake()
        {
            _block = GetComponent<UIBlock>();
        }

        private void OnEnable()
        {
            _state.Set(DesignButtonState.Idle);

            _block.RegisterEventTargetProvider(this);

            _block.AddGestureHandler<Gesture.OnClick, DesignButton>(HandleClicked);
            _block.AddGestureHandler<Gesture.OnHover, DesignButton>(OnHover);
            _block.AddGestureHandler<Gesture.OnUnhover, DesignButton>(OnUnhover);
            _block.AddGestureHandler<Gesture.OnPress, DesignButton>(OnPress);
            _block.AddGestureHandler<Gesture.OnRelease, DesignButton>(OnRelease);
            _block.AddGestureHandler<Gesture.OnCancel, DesignButton>(OnCancel);

            var lifetime = this.GetObjectLifetime();

            foreach (var behaviour in _behaviours)
                behaviour.Construct(this, lifetime);
        }

        private void OnDisable()
        {
            _block.RemoveGestureHandler<Gesture.OnClick, DesignButton>(HandleClicked);
            _block.RemoveGestureHandler<Gesture.OnHover, DesignButton>(OnHover);
            _block.RemoveGestureHandler<Gesture.OnUnhover, DesignButton>(OnUnhover);
            _block.RemoveGestureHandler<Gesture.OnPress, DesignButton>(OnPress);
            _block.RemoveGestureHandler<Gesture.OnRelease, DesignButton>(OnRelease);
            _block.RemoveGestureHandler<Gesture.OnCancel, DesignButton>(OnCancel);

            _block.UnregisterEventTargetProvider(this);
        }

        private void OnValidate()
        {
            if (_behaviours == null || _behaviours.Length == 0)
                _behaviours = GetComponentsInChildren<DesignButtonBehaviour>();
        }

        public void Lock()
        {
            _isLocked = true;
        }

        public void Unlock()
        {
            _isLocked = false;
        }

        private void HandleClicked(Gesture.OnClick data, DesignButton visuals)
        {
            if (_isLocked == true)
                return;

            _clicked.Invoke();
        }

        private void OnHover(Gesture.OnHover data, DesignButton visuals)
        {
            if (_isLocked == true)
                return;

            SetState(DesignButtonState.Hovered);
        }

        private void OnUnhover(Gesture.OnUnhover data, DesignButton visuals)
        {
            if (_isLocked == true)
                return;

            SetState(DesignButtonState.Idle);
        }

        private void OnPress(Gesture.OnPress data, DesignButton visuals)
        {
            if (_isLocked == true)
                return;

            SetState(DesignButtonState.Pressed);
        }

        private void OnRelease(Gesture.OnRelease data, DesignButton visuals)
        {
            if (_isLocked == true)
                return;

            SetState(DesignButtonState.Hovered);
        }

        private void OnCancel(Gesture.OnCancel data, DesignButton visuals)
        {
            if (_isLocked == true)
                return;

            SetState(DesignButtonState.Idle);
        }

        private void SetState(DesignButtonState state)
        {
            _state.Set(state);
        }

        public bool TryGetTarget(IEventTarget eventReceiver, Type eventType, out IEventTarget eventTarget)
        {
            eventTarget = this;
            return true;
        }

        [Button("Scan behaviours")]
        private void ScanBehaviours()
        {
            _behaviours = GetComponentsInChildren<DesignButtonBehaviour>();
        }
    }
}