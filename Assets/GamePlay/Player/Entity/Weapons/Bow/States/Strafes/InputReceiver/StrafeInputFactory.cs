using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.InputName, menuName = BowStrafeRoutes.InputPath)]
    public class StrafeInputFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<StrafeInputReceiver>()
                .As<IStrafeInputReceiver>()
                .AsCallbackListener();
        }
    }
}