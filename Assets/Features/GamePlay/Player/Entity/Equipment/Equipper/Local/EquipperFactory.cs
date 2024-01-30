using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Equipment.Equipper.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Equipper.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.LocalName,
        menuName = EquipperRoutes.LocalPath)]
    public class EquipperFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<Equipper>()
                .WithParameter(utils.Scope)
                .As<IEquipper>();
        }
    }
}