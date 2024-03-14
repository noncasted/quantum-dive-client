using System.Collections.Generic;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Mappers.States.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Mappers.States.Runtime
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