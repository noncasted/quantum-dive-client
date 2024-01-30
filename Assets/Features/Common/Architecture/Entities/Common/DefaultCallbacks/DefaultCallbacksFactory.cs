﻿using Common.Architecture.Entities.Runtime.Callbacks;

namespace Common.Architecture.Entities.Common.DefaultCallbacks
{
    public class DefaultCallbacksFactory : ICallbacksFactory
    {
        /// <summary>
        /// 0 - ContainerBuilt
        /// 1 - Awake
        /// 2 - AwakeAsync
        /// 3 - Enabled
        /// 4 - EnabledAsync
        /// 5 - OnLoaded
        /// 6 - OnLoadedAsync
        /// 7 - OnDisabled
        /// </summary>
        /// <param name="callbacks"></param>
        /// <param name="data"></param>
        public void AddCallbacks(IEntityCallbacks callbacks)
        {
            callbacks.AddScopeCallback<IEntityAwakeListener>(
                listener => listener.OnAwake(), CallbackStage.Construct, 1000);
            callbacks.AddScopeAsyncCallback<IEntityAwakeAsyncListener>(
                listener => listener.OnAwakeAsync(), CallbackStage.Construct, 2000);
            callbacks.AddScopeAsyncCallback<IEntityLoadedAsyncListener>(
                listener => listener.OnLoadedAsync(), CallbackStage.Construct, 4000);

            callbacks.AddScopeCallback<IEntityEnableListener>(
                listener => listener.OnEnabled(), CallbackStage.Enable, 0);
            callbacks.AddScopeAsyncCallback<IEntityEnableAsyncListener>(
                listener => listener.OnEnabledAsync(), CallbackStage.Construct, 1000);

            callbacks.AddScopeCallback<IEntityDisableListener>(
                listener => listener.OnDisabled(), CallbackStage.Disable, 0);

            callbacks.AddScopeAsyncCallback<IEntityDisableAsyncListener>(
                listener => listener.OnDisabledAsync(), CallbackStage.Dispose, 1000);

            callbacks.AddScopeCallback<IEntityDestroyListener>(
                listener => listener.OnDestroyed(), CallbackStage.Dispose, 1000);
        }
    }
}