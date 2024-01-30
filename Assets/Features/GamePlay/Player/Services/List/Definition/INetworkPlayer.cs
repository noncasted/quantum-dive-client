using Features.GamePlay.Player.Entity.Setup.Root.Common;
using Ragon.Client;

namespace Features.GamePlay.Player.Services.List.Definition
{
    public interface INetworkPlayer
    {
        RagonEntity Entity { get; }
        IPlayerRoot Root { get; }
    }
}