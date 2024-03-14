using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime
{
    [CreateAssetMenu(fileName = TargetsSearcherRoutes.ComponentName, menuName = TargetsSearcherRoutes.ComponentPath)]
    public class TargetsSearcherFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<TargetsSearcher>()
                .As<ITargetsSearcher>();
        }
    }
}