using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.FactoryName, menuName = EquipperRoutes.FactoryPath)]
    public class EquipmentFactoryComponentFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<EquipmentFactory>()
                .As<IEquipmentFactory>()
                .WithParameter(utils.Scope);
        }
    }
}