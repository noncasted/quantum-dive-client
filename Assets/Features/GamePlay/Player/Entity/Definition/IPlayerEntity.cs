using Ragon.Client;

namespace GamePlay.Player.Entity.Definition
{
    public interface IPlayerEntity
    {
        RagonEntity Entity { get; }
        IPlayerRoot Root { get; }
    }
}