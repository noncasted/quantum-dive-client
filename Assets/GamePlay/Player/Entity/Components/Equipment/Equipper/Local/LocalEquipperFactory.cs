using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
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
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<LocalEquipper>()
                .As<IEquipper>();
        }
    }
}