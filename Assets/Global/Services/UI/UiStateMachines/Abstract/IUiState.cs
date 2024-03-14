namespace Global.UI.UiStateMachines.Runtime
{
    public interface IUiState
    {
        IUIConstraints Constraints { get; }
        string Name { get; }

        void Recover();
        void Exit();
    }
}