﻿using Common.DataTypes.Runtime.Reactive;
using GamePlay.Player.Entity.Views.Transforms.Abstract;
using Global.Inputs.Utils.Abstract;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Local
{
    public class RollInput : IEntitySwitchLifetimeListener, IRollInput
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
        private readonly ViewableDelegate _performed = new();

        public IViewableDelegate Performed => _performed;

        public Vector2 Direction => _inputProjection.GetDirectionFrom(_position.Position);
        public bool HasInput => _hasInput;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _rollInputView.Performed.Listen(lifetime, OnRollPerformed);
            _rollInputView.Canceled.Listen(lifetime, OnRollCanceled);
        }

        private void OnRollPerformed()
        {
            _hasInput = true;
            _performed?.Invoke();
        }

        private void OnRollCanceled()
        {
            _hasInput = false;
        }
    }
}