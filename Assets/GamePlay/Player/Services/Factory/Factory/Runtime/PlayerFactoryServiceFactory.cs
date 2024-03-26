using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Types.Local;
using GamePlay.Player.Entity.Types.Remote;
using GamePlay.Player.Services.Factory.Factory.Abstract;
using GamePlay.Player.Services.Factory.Factory.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerFactoryRoutes.ServiceName,
        menuName = PlayerFactoryRoutes.ServicePath)]
    public class PlayerFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private DefaultEquipmentConfig _equipment;

        [SerializeField] private LocalPlayerConfig _localConfig;
        [SerializeField] private RemotePlayerConfig _remoteConfig;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<PlayerFactory>()
                .As<IPlayerFactory>()
                .WithParameter(_equipment)
                .WithParameter(_localConfig)
                .WithParameter(_remoteConfig)
                .AsCallbackListener();
        }
    }
}