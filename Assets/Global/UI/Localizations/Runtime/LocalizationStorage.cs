using System.Collections.Generic;
using Common.DataTypes.Runtime.Attributes;
using Common.DataTypes.Runtime.Collections;
using Global.UI.Localizations.Common;
using Global.UI.Localizations.Texts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Localizations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.StorageName, menuName = LocalizationRoutes.StoragePath)]
    public class LocalizationStorage : ScriptableObject, ILocalizationStorage
    {
        [SerializeField] [CreateSO] private LanguageTextDataRegistry _registry;

        public IReadOnlyList<LanguageTextData> GetDatas()
        {
            return _registry.Objects;
        }
    }
}