using Global.Config.Runtime;
using Internal.Scope;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Architecture.Mocks.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalMockConfig", menuName = "Common/GlobalMockConfig")]
    public class GlobalMockConfig : ScriptableObject
    {
        [SerializeField] private InternalScopeConfig _internal;
        [SerializeField] private GlobalScopeConfig _global;

        public InternalScopeConfig Internal => _internal;
        public GlobalScopeConfig Global => _global;
    }
}