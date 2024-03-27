using System.Collections.Generic;
using GamePlay.Services.Projectiles.Entity.Views.Facade;
using GamePlay.Services.Projectiles.Registry.Definition;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Services.Projectiles.Pool
{
    public class ProjectilesPool : IScopeAwakeListener, IScopeDisableListener, IProjectilesPool
    {

        public void OnAwake()
        {

        }

        public void OnDisabled()
        {
  
        }

        public void CreatePools(
            IServiceCollection services,
            Scene targetScene,
            IReadOnlyList<IProjectileDefinition> definitions)
        {
            foreach (var definition in definitions)
            {

       
            }
        }

        public IProjectileView Get(IProjectileDefinition definition, Vector3 position)
        {
            return null;
        }

        private Transform CreateParent(string assetName, Scene targetScene)
        {
            var root = new GameObject($"{assetName} objects")
            {
                transform =
                {
                    position = Vector3.zero
                }
            };

            SceneManager.MoveGameObjectToScene(root, targetScene);

            return root.transform;
        }
    }
}