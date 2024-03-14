using System.Collections.Generic;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Mappers.Equipment.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Mappers.Equipment.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerEquipmentMapperRoutes.ServiceName,
        menuName = PlayerEquipmentMapperRoutes.ServicePath)]
    public class PlayerEquipmentMapperFactory : ScriptableRegistry<EquipmentConfig>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<PlayerEquipmentMapper>()
                .As<IPlayerEquipmentMapper>()
                .WithParameter<IReadOnlyList<IEquipmentConfig>>(Objects)
                .AsSelfResolvable();
        }
    }
}