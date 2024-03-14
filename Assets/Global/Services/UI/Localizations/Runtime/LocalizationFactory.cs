using Cysharp.Threading.Tasks;
using Global.UI.Localizations.Abstract;
using Global.UI.Localizations.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Localizations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.ServiceName, menuName = LocalizationRoutes.ServicePath)]
    public class LocalizationFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LocalizationStorage _storage;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<Localization>()
                .WithParameter<ILocalizationStorage>(_storage)
                .As<ILocalization>()
                .AsCallbackListener();

            services.Register<LanguageConverter>()
                .As<ILanguageConverter>();
        }
    }
}