﻿using Common.DataTypes.Runtime.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Environment.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Environment.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelEnvironmentRoutes.ServiceName,
        menuName = LevelEnvironmentRoutes.ServicePath)]
    public class LevelEnvironmentFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [CreateSO] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var factory = await GetFactory();
            await factory.Create(services, utils);

            return;

            async UniTask<ILevelSceneServicesFactory> GetFactory()
            {
                if (utils.IsMock == true)
                    return FindFirstObjectByType<LevelSceneServicesFactory>();

                var (result, searched) = await utils.SceneLoader.LoadTyped<ILevelSceneServicesFactory>(_scene);
                SceneManager.SetActiveScene(result.Scene);
                return searched;
            }
        }
    }
}