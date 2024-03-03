﻿using Internal.Abstract;
using Internal.Options.Implementations;
using Internal.Options.Runtime;
using Internal.Scenes.Abstract;
using Internal.Scenes.Addressable;
using Internal.Scenes.Common;
using Internal.Scenes.Logs;
using Internal.Scenes.Native;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Internal.Scenes.Root
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.ServiceName,
        menuName = ScenesFlowRoutes.ServicePath)]
    public class ScenesFlowFactory : ScriptableObject, IInternalServiceFactory
    {
        [SerializeField] [Indent] private ScenesFlowLogSettings _logSettings;

        public void Create(IOptions options, IContainerBuilder services)
        {
            if (options.GetOptions<AssetsOptions>().UseAddressables == true)
            {
                services.Register<AddressablesSceneLoader>(Lifetime.Singleton)
                    .As<ISceneLoader>();

                services.Register<AddressablesScenesUnloader>(Lifetime.Singleton)
                    .As<ISceneUnloader>();
            }
            else
            {
                services.Register<NativeSceneLoader>(Lifetime.Singleton)
                    .As<ISceneLoader>();

                services.Register<NativeSceneUnloader>(Lifetime.Singleton)
                    .As<ISceneUnloader>();
            }
            
            services.Register<ScenesFlowLogger>(Lifetime.Singleton)
                .WithParameter(_logSettings);
        }
    }
}