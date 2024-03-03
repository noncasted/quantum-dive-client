﻿using System.Collections.Generic;
using Internal.Scenes.Data;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime.Services
{
    public interface IScopeConfig
    {
        LifetimeScope ScopePrefab { get; }
        ISceneAsset ServicesScene { get; }
        bool IsMock { get; }

        IReadOnlyList<IServiceFactory> Services { get; }
        IReadOnlyList<IServicesCompose> Composes { get; }
    }
}