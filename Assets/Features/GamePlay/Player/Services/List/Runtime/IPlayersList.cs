using GamePlay.Player.Services.List.Definition;
using Ragon.Client;

namespace GamePlay.Player.Services.List.Runtime
{
    public interface IPlayersList
    {
        void Add(RagonPlayer player, INetworkPlayer root);
        INetworkPlayer Get(RagonPlayer player);
    }
}