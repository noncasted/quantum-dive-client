using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Services.Registries.States.Common;
using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GamePlay.Player.Services.Registries.States.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = StatesRegistryRoutes.ServiceName,
        menuName = StatesRegistryRoutes.ServicePath)]
    public class StateDefinitionsRegistryFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private PlayerStateDefinition[] _definitions;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<StateDefinitionsRegistry>()
                .As<IStateDefinitionsRegistry>()
                .WithParameter(_definitions);
        }
        
        [Button("Scan")]
        private void Scan()
        {
#if UNITY_EDITOR
            var definitions = new List<PlayerStateDefinition>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(PlayerStateDefinition)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<PlayerStateDefinition>(assetPath);

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