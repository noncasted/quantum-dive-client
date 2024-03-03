using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Common;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime
{
    [CreateAssetMenu(fileName = TargetsSearcherRoutes.ComponentName, menuName = TargetsSearcherRoutes.ComponentPath)]
    public class TargetsSearcherFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<TargetsSearcher>()
                .As<ITargetsSearcher>();
        }
    }
}