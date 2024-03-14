using System.Collections.Generic;
using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Services.Mappers.States.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Mappers.States.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerStateMapperRoutes.ServiceName,
        menuName = PlayerStateMapperRoutes.ServicePath)]
    public class PlayerStateMapperFactory : ScriptableRegistry<PlayerStateDefinition>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<PlayerStateMapper>()
                .As<IPlayerStateMapper>()
                .WithParameter<IReadOnlyList<PlayerStateDefinition>>(Objects);
        }
    }
}