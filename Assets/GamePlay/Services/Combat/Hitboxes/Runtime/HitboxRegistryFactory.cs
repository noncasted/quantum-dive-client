using Cysharp.Threading.Tasks;
using GamePlay.Hitboxes.Common;
using GamePlay.Services.Combat.Hitboxes.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Hitboxes.Runtime
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