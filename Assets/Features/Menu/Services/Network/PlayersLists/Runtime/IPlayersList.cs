using System;
using System.Collections.Generic;
using Ragon.Client;

namespace Menu.Network.PlayersLists.Runtime
{
    public interface IPlayersList
    {
        event Action<IReadOnlyList<PlayerData>> Changed;

        void AddPlayer(RagonPlayer player);
    }
}