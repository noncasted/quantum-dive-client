﻿using Internal.Scopes.Abstract.Options;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Options.Implementations
{
    [InlineEditor]
    public class PlatformOptions : OptionsEntry
    {
        [SerializeField] private TargetPlatform _platform;

        public TargetPlatform Platform => _platform;
        
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