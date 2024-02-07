using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using GamePlay.Combat.Projectiles.Common;
using GamePlay.Combat.Projectiles.Registry.Definition;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ProjectilesRoutes.DefinitionsRegistryName,
        menuName = ProjectilesRoutes.DefinitionsRegistryPath)]
    public class ProjectileDefinitionsRegistryFactory : ScriptableObject
    {
        [SerializeField] private ProjectileDefinition[] _definitions;

        public IReadOnlyList<IProjectileDefinition> Definitions => _definitions;

        public void Create(IServiceCollection services)
        {
            services.Register<ProjectileDefinitionsRegistry>()
                .As<IProjectileDefinitionsRegistry>()
                .WithParameter(Definitions);
        }
        
        [Button("Scan")]
        private void Scan()
        {
#if UNITY_EDITOR
            var definitions = new List<ProjectileDefinition>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(ProjectileDefinition)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<ProjectileDefinition>(assetPath);

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