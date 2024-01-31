using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Registries.Equipment.Common;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Player.Registries.Equipment.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipmentRegistryRoutes.ServiceName,
        menuName = EquipmentRegistryRoutes.ServicePath)]
    public class EquipmentRegistryFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EquipmentConfig[] _equipments;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EquipmentRegistry>()
                .As<IEquipmentRegistry>()
                .WithParameter(_equipments)
                .AsSelfResolvable();
        }
        
        [Button("Scan")]
        private void Scan()
        {
#if UNITY_EDITOR
            var definitions = new List<EquipmentConfig>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(EquipmentConfig)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<EquipmentConfig>(assetPath);

                if (asset == null)
                    continue;

                definitions.Add(asset);
            }

            Undo.RecordObject(this, "Assign definitions");

            _equipments = definitions.ToArray();

            Undo.RecordObject(this, "Assign definitions");
#endif
        }
    }
}