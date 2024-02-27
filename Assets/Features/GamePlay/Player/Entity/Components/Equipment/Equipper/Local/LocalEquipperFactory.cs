using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Common;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Factory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.LocalName,
        menuName = EquipperRoutes.LocalPath)]
    public class LocalEquipperFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalEquipper>()
                .As<IEquipper>();
        }
    }
}