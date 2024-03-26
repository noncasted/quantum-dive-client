using Internal.Scopes.Abstract.Options;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Options.Implementations
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Options_Platform", menuName = "Internal/Options/Platform")]
    public class PlatformOptions : OptionsEntry
    {
        public bool IsEditor
        {
            get
            {
#if UNITY_EDITOR
                return true;
#endif
                return false;
            }
        }
    }
}