namespace Global.UI.StateMachines.Abstract
{
    public interface IUiState
    {
        IUIConstraints Constraints { get; }
        string Name { get; }

        void Recover();
        void Exit();
    }
}