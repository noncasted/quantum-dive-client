using Menu.Lobby.UI.Runtime.Status;

namespace Menu.Lobby.UI.Runtime.View
{
    public interface ILobbyView
    {
        ILobbyStatus Status { get; }
        
        void Open();
        void Close();
    }
}