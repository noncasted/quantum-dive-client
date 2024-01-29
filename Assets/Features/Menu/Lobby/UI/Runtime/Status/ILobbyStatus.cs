namespace Menu.Lobby.UI.Runtime.Status
{
    public interface ILobbyStatus
    {
        void ShowPlayButton();
        void HidePlayButton();
        void ShowTimer();
        void HideTimer();
        
        void Construct(string roomId);
    }
}