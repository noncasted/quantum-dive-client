using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.Deaths.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Deaths.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DeathRoutes.StateName,
        menuName = DeathRoutes.StatePath)]
    public class LocalDeathFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private DeathDefinition _definition;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<LocalDeath>()
                .WithParameter(_definition)
                .As<IDeath>();
        }
    }
}