using System;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using Global.Inputs.Utils.Runtime.Projection;
using Global.Inputs.View.Implementations.Movement;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    public class RollInput : IEntitySwitchListener, IRollInput
    {
        public RollInput(
            IRollInputView rollInputView,
            IInputProjection inputProjection,
            IPlayerPosition position)
        {
            _rollInputView = rollInputView;
            _inputProjection = inputProjection;
            _position = position;
        }

        private readonly IRollInputView _rollInputView;
        private readonly IInputProjection _inputProjection;
        private readonly IPlayerPosition _position;

        private Vector2 _direction;
        private bool _hasInput;

        public event Action Performed;

        public Vector2 Direction => _inputProjection.GetDirectionFrom(_position.Position);
        public bool HasInput => _hasInput;

        public void OnEnabled()
        {
            _rollInputView.Performed += OnRollPerformed;
            _rollInputView.Canceled += OnRollCanceled;
        }

        public void OnDisabled()
        {
            _rollInputView.Performed -= OnRollPerformed;
            _rollInputView.Canceled -= OnRollCanceled;
        }

        private void OnRollPerformed()
        {
            _hasInput = true;

            Performed?.Invoke();
        }

        private void OnRollCanceled()
        {
            _hasInput = false;
        }
    }
}