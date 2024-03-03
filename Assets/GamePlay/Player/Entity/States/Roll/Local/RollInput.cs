using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.Architecture.Lifetimes.Viewables;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using Global.Inputs.Utils.Runtime.Projection;
using Global.Inputs.View.Implementations.Movement;
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
        private readonly IViewableDelegate _performed = new ViewableDelegate();

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

            Performed?.Invoke();
        }

        private void OnRollCanceled()
        {
            _hasInput = false;
        }
    }
}