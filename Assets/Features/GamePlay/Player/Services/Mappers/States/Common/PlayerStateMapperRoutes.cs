using Features.GamePlay.Player.Services.Common;
using GamePlay.Common.Paths;

namespace GamePlay.Player.Registries.States.Common
{
    public class PlayerStateMapperRoutes
    {
        public const string ServiceName = PlayerServicesPrefixes.Mapper + "States";
        public const string ServicePath = PlayerServicesRoutes.Root + "Mappers/States";
    }
}