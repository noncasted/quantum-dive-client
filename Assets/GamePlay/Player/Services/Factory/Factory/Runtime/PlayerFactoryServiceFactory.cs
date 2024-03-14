using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Types.Local;
using GamePlay.Player.Entity.Types.Remote;
using GamePlay.Player.Factory.Factory.Common;
using GamePlay.Player.Factory.Factory.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Factory.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerFactoryRoutes.ServiceName,
        menuName = PlayerFactoryRoutes.ServicePath)]
    public class PlayerFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private PlayerFactoryLogSettings _logSettings;
        [SerializeField] private DefaultEquipmentConfig _equipment;

        [SerializeField] private LocalPlayerConfig _localConfig;
        [SerializeField] private RemotePlayerConfig _remoteConfig;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<PlayerFactoryLogger>()
                .WithParameter(_logSettings);

            services.Register<PlayerFactory>()
                .As<IPlayerFactory>()
                .WithParameter(_equipment)
                .WithParameter(_localConfig)
                .WithParameter(_remoteConfig)
                .AsCallbackListener();
        }
    }
}