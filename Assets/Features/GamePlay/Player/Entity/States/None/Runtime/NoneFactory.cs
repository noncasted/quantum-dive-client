using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.None.Common;
using GamePlay.Player.Entity.States.None.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.None.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NoneRoutes.StateName,
        menuName = NoneRoutes.StatePath)]
    public class NoneFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private NoneLogSettings _logSettings;
        [SerializeField] [Indent] private NoneDefinition _definition;

        public void Create(IServiceCollection services, ICallbackRegister callbackRegister)
        {
            services.Register<NoneLogger>()
                .WithParameter(_logSettings);

            services.Register<None>()
                .WithParameter(_definition)
                .As<INone>();
        }
    }
}