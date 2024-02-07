using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Setup.Config.Local;
using GamePlay.Player.Entity.Setup.Config.Remote;
using GamePlay.Player.Services.Factory.Factory.Common;
using GamePlay.Player.Services.Factory.Factory.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerFactoryRoutes.ServiceName,
        menuName = PlayerFactoryRoutes.ServicePath)]
    public class PlayerFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private PlayerFactoryLogSettings _logSettings;
        [SerializeField] [Indent] private DefaultEquipmentConfig _equipment;
        
        [SerializeField] [Indent] private LocalPlayerConfig _localConfig;
        [SerializeField] [Indent] private RemotePlayerConfig _remoteConfig;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
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