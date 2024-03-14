﻿using System.Collections.Generic;
using GamePlay.Projectiles.Common;
using GamePlay.Projectiles.Registry.Definition;
using GamePlay.Services.Combat.Projectiles.Registry.Abstract;
using Internal.Scopes.Abstract.Containers;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace GamePlay.Projectiles.Registry.Runtime
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