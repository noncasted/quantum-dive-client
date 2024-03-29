﻿using Common.DataTypes.Runtime.Reactive;
using GamePlay.Player.Entity.States.Runs.Remote;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    public class RunInput : IEntitySwitchLifetimeListener, IRunInput
    {
        public RunInput(
            IMovementInputView inputView,
            IRunInputSync sync)
        {
            _inputView = inputView;
            _sync = sync;
        }

        private readonly IMovementInputView _inputView;
        private readonly IRunInputSync _sync;

        private Vector2 _direction;
        private bool _hasInput;

        private readonly ViewableDelegate _performed = new();
        private readonly ViewableDelegate _canceled = new();

        public IViewableDelegate Performed => _performed;
        public IViewableDelegate Canceled => _canceled;

        public Vector2 Direction => _direction;
        public bool HasInput => _hasInput;

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _inputView.Performed.Listen(lifetime, OnInputView);
            _inputView.Canceled.Listen(lifetime, OnCanceled);
        }

        private void OnInputView(Vector2 direction)
        {
            _direction = direction;
            _sync.OnInput(direction);
            _hasInput = true;

            _performed?.Invoke();
        }

        private void OnCanceled()
        {
            _direction = Vector2.zero;
            _sync.OnInput(_direction);
            _hasInput = false;

            _canceled?.Invoke();
        }
    }
}