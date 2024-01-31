using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Components.Equipment.Equipper.Factory;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.RemoteName,
        menuName = EquipperRoutes.RemotePath)]
    public class RemoteEquipperFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteEquipper>()
                .As<IEquipperSync>()
                .AsSelf();
            
            services.Register<EquipmentFactory>()
                .WithParameter(utils.Scope)
                .As<IEquipmentFactory>();
        }
    }
}