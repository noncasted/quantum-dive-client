using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Sword.Components.Root.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordRootRoutes.LocalName, menuName = SwordRootRoutes.LocalPath)]
    public class SwordRootFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<SwordRoot>()
                .As<IEquipment>()
                .AsCallbackListener();
        }
    }
}