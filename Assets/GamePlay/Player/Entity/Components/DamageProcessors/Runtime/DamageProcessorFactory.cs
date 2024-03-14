using GamePlay.Player.Entity.Components.DamageProcessors.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DamageProcessorRoutes.ComponentName,
        menuName = DamageProcessorRoutes.ComponentPath)]
    public class DamageProcessorFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private DamageProcessorConfigAsset _config;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<DamageProcessor>()
                .WithParameter(_config)
                .As<IDamageProcessor>()
                .AsCallbackListener();
        }
    }
}