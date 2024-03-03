using Global.UI.UiStateMachines.Runtime;

namespace GamePlay.Player.UI.Overlay.Runtime.State
{
    public class PlayerOverlay : IUiState, IPlayerOverlay
    {
        public PlayerOverlay(
            IPlayerOverlayView view,
            IUiStateMachine stateMachine,
            UiConstraints constraints)
        {
            Constraints = constraints;
            _view = view;
            _stateMachine = stateMachine;
        }

        private readonly IPlayerOverlayView _view;
        private readonly IUiStateMachine _stateMachine;

        public UiConstraints Constraints { get; }
        public string Name => "PlayerOverlay";

        public void Show()
        {
            _view.Body.SetActive(true);
        }

        public void Hide()
        {
            _view.Body.SetActive(false);
        }

        public void Recover()
        {
            _view.Body.SetActive(true);
        }

        public void Exit()
        {
            _view.Body.SetActive(true);
        }
    }
}