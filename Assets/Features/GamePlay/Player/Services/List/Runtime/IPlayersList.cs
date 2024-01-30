using Features.GamePlay.Player.Services.List.Definition;
using Ragon.Client;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public interface IPlayersList
    {
        void Add(RagonPlayer player, INetworkPlayer root);
        INetworkPlayer Get(RagonPlayer player);
    }
}