using Ragon.Client;

namespace GamePlay.Player.Entity.Common.Definition
{
    public interface IPlayerEntity
    {
        RagonEntity Entity { get; }
        IPlayerRoot Root { get; }
    }
}