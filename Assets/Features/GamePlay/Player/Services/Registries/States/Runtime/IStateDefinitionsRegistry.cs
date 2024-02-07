using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Services.Registries.States.Runtime
{
    public interface IStateDefinitionsRegistry
    {
        int GetId(PlayerStateDefinition definition);
        PlayerStateDefinition GetDefinition(int id);
    }
}