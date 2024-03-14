using Global.Config.Runtime;
using Internal.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Scopes.Mocks.Runtime
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