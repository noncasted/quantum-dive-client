using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Spawn.Pool.Common;
using Internal.Services.Scenes.Data;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Pool.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyPoolRoutes.PoolName,
        menuName = EnemyPoolRoutes.PoolPath)]
    public class EnemyPoolFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] [Scene] private SceneData _poolScene;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var loadResult = await utils.SceneLoader.Load(_poolScene);

            services.Register<EnemyPool>()
                .As<IEnemyPool>()
                .WithParameter(loadResult.Scene)
                .AsCallbackListener();
        }
    }
}