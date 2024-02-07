using GamePlay.Player.Entity.Definition;
using Ragon.Client;

namespace GamePlay.Player.List.Runtime
{
    public interface IPlayersList
    {
        void Add(RagonPlayer player, IPlayerEntity root);
        IPlayerEntity Get(RagonPlayer player);
    }
}