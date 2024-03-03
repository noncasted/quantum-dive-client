using Internal.Options.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Options.Implementations
    {
        [InlineEditor]
        public class VersionOptions : OptionsEntry
        {
            [SerializeField] private string _value;

            public string Value => _value;
        }
    }
