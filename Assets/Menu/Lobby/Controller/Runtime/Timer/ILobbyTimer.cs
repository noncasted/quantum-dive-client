using Cysharp.Threading.Tasks;

namespace Menu.Lobby.Controller.Runtime.Timer
{
    public interface ILobbyTimer
    {
        UniTask Delay();
    }
}