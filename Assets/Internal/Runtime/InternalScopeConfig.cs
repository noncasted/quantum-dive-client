using System.Collections.Generic;
using Internal.Abstract;
using Internal.Common;
using Internal.Loggers.Runtime;
using Internal.Scenes.Root;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Scope
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InternalRoutes.ConfigName, menuName = InternalRoutes.ConfigPath)]
    public class InternalScopeConfig : ScriptableObject, IInternalScopeConfig
    {
        [SerializeField] private ScenesFlowFactory _scenes;
        [SerializeField] private LoggerFactory _logger;
        [SerializeField] private Options.Runtime.Options _options;
        [SerializeField] private InternalScope _scope;

        public InternalScope Scope => _scope;
        public Options.Runtime.Options Options => _options;
        public IReadOnlyList<IInternalServiceFactory> Services => GetServices();

        private IReadOnlyList<IInternalServiceFactory> GetServices()
        {
            return new IInternalServiceFactory[]
            {
                _scenes,
                _logger
            };
        }
    }
}