using System.Collections.Generic;
using Internal.Scopes.Abstract.Environments;
using Internal.Scopes.Abstract.Options;
using Internal.Services.Options.Common;
using Internal.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Options.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Options", menuName = OptionRoutes.RootPath)]
    public class Options : SerializedScriptableObject, IOptions, IOptionsSetup
    {
        [SerializeField] private List<EnvironmentDefinition> _optionsPriority;
        [SerializeField] private Dictionary<EnvironmentDefinition, OptionsRegistry> _registries;

        public void Setup()
        {
            foreach (var (_, registry) in _registries)
                registry.CacheRegistry();
        }

        public T GetOptions<T>() where T : OptionsEntry
        {
            foreach (var environmentType in _optionsPriority)
            {
                var currentEnvironment = _registries[environmentType];

                if (currentEnvironment.TryGetEntry<T>(out var environmentEntry) == true)
                    return environmentEntry;
            }
            
            return null;
        }
    }
}