﻿using Cysharp.Threading.Tasks;

namespace Common.Architecture.Entities.Common.DefaultCallbacks
{
    public interface IEntityAwakeListener
    {
        void OnAwake();
    }

    public interface IEntityAwakeAsyncListener
    {
        UniTask OnAwakeAsync();
    }
    
    public interface IEntityLoadedAsyncListener
    {
        UniTask OnLoadedAsync();
    }

    public interface IEntityEnableListener
    {
        void OnEnabled();
    }

    public interface IEntityEnableAsyncListener
    {
        UniTask OnEnabledAsync();
    }

    public interface IEntityDisableListener
    {
        void OnDisabled();
    }

    public interface IEntityDisableAsyncListener
    {
        UniTask OnDisabledAsync();
    }
    
    public interface IEntityDestroyListener
    {
        void OnDestroyed();
    }

    public interface IEntitySwitchListener : IEntityEnableListener, IEntityDisableListener
    {
    }
}