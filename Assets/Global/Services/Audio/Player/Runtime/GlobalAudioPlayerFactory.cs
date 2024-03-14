using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Global.Audio.Player.Common;
using Global.Services.Audio.Player.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAudioPlayerRoutes.ServiceName,
        menuName = GlobalAudioPlayerRoutes.ServicePath)]
    public class GlobalAudioPlayerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private GlobalAudioPlayer _prefab;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var player = Instantiate(_prefab);
            player.name = "AudioPlayer";

            services.RegisterComponent(player)
                .As<IGlobalVolume>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(player.gameObject);
        }
    }
}