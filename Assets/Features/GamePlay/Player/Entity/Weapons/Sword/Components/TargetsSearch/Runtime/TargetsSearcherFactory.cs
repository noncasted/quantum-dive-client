using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Common;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime
{
    [CreateAssetMenu(fileName = TargetsSearcherRoutes.ComponentName, menuName = TargetsSearcherRoutes.ComponentPath)]
    public class TargetsSearcherFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<TargetsSearcher>()
                .As<ITargetsSearcher>();
        }
    }
}