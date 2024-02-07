using GamePlay.Player.List.Definition;
using Ragon.Client;

namespace GamePlay.Player.List.Runtime
{
    public interface IPlayersList
    {
        void Add(RagonPlayer player, INetworkPlayer root);
        INetworkPlayer Get(RagonPlayer player);
    }
}