using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Services.Network.DataBridges.States.Common;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Enemies.Services.Network.DataBridges.States.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = StatesRegistryRoutes.ServiceName,
        menuName = StatesRegistryRoutes.ServicePath)]
    public class EnemyStateDefinitionsRegistryFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EnemyStateDefinition[] _definitions;

        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemyStateDefinitionsRegistry>()
                .As<IEnemyStateDefinitionsRegistry>()
                .WithParameter(_definitions);
        }
        
        [Button("Scan")]
        private void Scan()
        {
#if UNITY_EDITOR
            var definitions = new List<EnemyStateDefinition>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(EnemyStateDefinition)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<EnemyStateDefinition>(assetPath);

                if (asset == null)
                    continue;

                definitions.Add(asset);
            }

            Undo.RecordObject(this, "Assign definitions");

            _definitions = definitions.ToArray();

            Undo.RecordObject(this, "Assign definitions");
#endif
        }
    }
}