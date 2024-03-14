using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Bow.Components.Root.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowRootRoutes.LocalName, menuName = BowRootRoutes.LocalPath)]
    public class BowRootFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<BowRoot>()
                .As<IEquipment>()
                .AsCallbackListener();
        }
    }
}