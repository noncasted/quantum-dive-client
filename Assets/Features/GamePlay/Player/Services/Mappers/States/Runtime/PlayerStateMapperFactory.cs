using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Registries.States.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Registries.States.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerStateMapperRoutes.ServiceName,
        menuName = PlayerStateMapperRoutes.ServicePath)]
    public class PlayerStateMapperFactory : ScriptableRegistry<PlayerStateDefinition>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PlayerStateMapper>()
                .As<IPlayerStateMapper>()
                .WithParameter(Objects);
        }
    }
}