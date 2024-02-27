using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.FactoryName, menuName = EquipperRoutes.FactoryPath)]
    public class EquipmentFactoryComponentFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<EquipmentFactory>()
                .As<IEquipmentFactory>()
                .WithParameter(utils.Scope);
        }
    }
}