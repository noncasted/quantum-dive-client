using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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
    public class EquipmentMapperFactory : ScriptableRegistry<EquipmentConfig>, IServiceFactory
    {
        [SerializeField] private EquipmentConfig[] _equipments;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EquipmentMapper>()
                .As<IEquipmentMapper>()
                .WithParameter(_equipments)
                .AsSelfResolvable();
        }
    }
}