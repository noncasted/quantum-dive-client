using System;
using Common.DataTypes.Runtime.Reactive;
using Global.UI.Design.Abstract.Buttons;
using Internal.Scopes.Abstract.Lifetimes;
using Nova;
using UnityEngine;

namespace Global.UI.Design.Runtime.Buttons
{
    public class DesignButtonColor : DesignButtonBehaviour
    {
        [SerializeField] private UIBlock _block;
        [SerializeField] private ButtonColorConfig _config;

        private float _currentTransitionTime;
        private Color _targetColor;
        private Color _fromColor;

        public override void Construct(IDesignButton button, IReadOnlyLifetime lifetime)
        {
            button.State.View(lifetime, OnStateChanged);
        }

        private void Update()
        {
            var progress = _currentTransitionTime / _config.StateTransitionTime;
            progress = Mathf.Clamp01(progress);

            var color = Color.Lerp(_fromColor, _targetColor, progress);
            _block.Color = color;

            _currentTransitionTime += Time.deltaTime;
        }

        private void OnStateChanged(DesignButtonState state)
        {
            var color = state switch
            {
                DesignButtonState.Idle => _config.Idle,
                DesignButtonState.Hovered => _config.Hovered,
                DesignButtonState.Pressed => _config.Pressed,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };

            _fromColor = _block.Color;
            _targetColor = color;
            _currentTransitionTime = 0f;
        }
    }
}