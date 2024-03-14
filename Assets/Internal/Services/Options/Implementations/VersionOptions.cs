using Internal.Scopes.Abstract.Options;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Options.Implementations
    {
        [InlineEditor]
        public class VersionOptions : OptionsEntry
        {
            [SerializeField] private string _value;

            public string Value => _value;
        }
    }
