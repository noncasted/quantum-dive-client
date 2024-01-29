using System.Collections.Generic;
using System.Linq;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;
using GamePlay.Enemies.Services.Spawn.Registry.Common;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDefinitionsRegistryRoutes.ServiceName,
        menuName = EnemyDefinitionsRegistryRoutes.ServicePath)]
    public class EnemyDefinitionsRegistryFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EnemyDefinition[] _definitions;

        public IReadOnlyList<EnemyDefinition> Definitions => _definitions;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var definitions = _definitions.Cast<IEnemyDefinition>().ToArray();
            services.Register<EnemyDefinitionsRegistry>()
                .As<IEnemyDefinitionsRegistry>()
                .WithParameter(definitions);
        }

        [Button("Scan")]
        private void Scan()
        {
#if UNITY_EDITOR
            var definitions = new List<EnemyDefinition>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(EnemyDefinition)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<EnemyDefinition>(assetPath);

                if (asset == null)
                    continue;

                definitions.Add(asset);
            }

            Undo.RecordObject(this, "Assign definitions");

            _definitions = definitions.ToArray();

            for (var i = 0; i < _definitions.Length; i++)
            {
                Undo.RecordObject(_definitions[i], "Assign id");
                _definitions[i].Construct(i);
                Undo.RecordObject(_definitions[i], "Assign id");
            }

            Undo.RecordObject(this, "Assign definitions");
#endif
        }
    }
}