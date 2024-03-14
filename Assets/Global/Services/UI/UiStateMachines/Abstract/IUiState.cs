namespace Global.UI.UiStateMachines.Abstract
{
    public interface IUiState
    {
        IUIConstraints Constraints { get; }
        string Name { get; }

        void Recover();
        void Exit();
    }
}