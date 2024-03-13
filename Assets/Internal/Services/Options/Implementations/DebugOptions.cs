﻿using Internal.Scopes.Abstract.Options;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Options.Implementations
{
    [InlineEditor]
    public class DebugOptions : OptionsEntry
    {
        [SerializeField] private bool _enableGizmos;
        [SerializeField] private bool _enableLogs;

        public bool EnableGizmos => _enableGizmos;
        public bool EnableLogs => _enableLogs;
    }
}