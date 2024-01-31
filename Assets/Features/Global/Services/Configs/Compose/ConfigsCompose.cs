using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using Features.Global.Services.Configs.Common;
using Features.Global.Services.Configs.Registry.Runtime;
using Features.Global.Services.Configs.Upgrades.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.Configs.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "ConfigsCompose", menuName = ConfigsRoutes.Root + "Compose")]
    public class ConfigsCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private ConfigsRegistryFactory _registry;
        [SerializeField] private UpgradesFactory _upgrades;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _registry,
            _upgrades
        };
    }
}