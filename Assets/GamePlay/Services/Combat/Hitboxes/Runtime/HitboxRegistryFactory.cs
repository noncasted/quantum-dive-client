using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using GamePlay.Combat.Hitboxes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Combat.Hitboxes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HitboxRegistryRoutes.ServiceName,
        menuName = HitboxRegistryRoutes.ServicePath)]
    public class HitboxRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<HitboxRegistry>()
                .As<IHitboxRegistry>();
        }
    }
}