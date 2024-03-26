using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Spawn.Pool.Abstract;
using GamePlay.Enemy.Spawn.Pool.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Pool.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyPoolRoutes.PoolName,
        menuName = EnemyPoolRoutes.PoolPath)]
    public class EnemyPoolFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private SceneData _poolScene;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var loadResult = await utils.SceneLoader.Load(_poolScene);

            services.Register<EnemyPool>()
                .As<IEnemyPool>()
                .WithParameter(loadResult.Scene)
                .AsCallbackListener();
        }
    }
}