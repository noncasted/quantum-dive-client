using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Hitboxes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Hitboxes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HitboxRegistryRoutes.ServiceName,
        menuName = HitboxRegistryRoutes.ServicePath)]
    public class HitboxRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<HitboxRegistry>()
                .As<IHitboxRegistry>();
        }
    }
}