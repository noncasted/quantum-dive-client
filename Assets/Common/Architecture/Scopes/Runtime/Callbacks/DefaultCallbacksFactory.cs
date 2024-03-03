using System;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Scopes.Runtime.Callbacks
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
        public void AddCallbacks(IScopeCallbacks callbacks, IScopeData data)
        {
            AddConstruct<IScopeBuiltListener>(listener => listener.OnContainerBuilt(data.Scope), 0);
            AddConstruct<IScopeAwakeListener>(listener => listener.OnAwake(), 1000);
            AddAsyncConstruct<IScopeAwakeAsyncListener>(listener => listener.OnAwakeAsync(), 2000);
            
            AddSetupComplete<IScopeLifetimeListener>(listener => listener.OnLifetimeCreated(data.Lifetime), 0);
            AddSetupComplete<IScopeEnableListener>(listener => listener.OnEnabled(), 1000);
            AddAsyncSetupComplete<IScopeEnableAsyncListener>(listener => listener.OnEnabledAsync(), 2000);
            AddSetupComplete<IScopeLoadListener>(listener => listener.OnLoaded(), 3000);
            AddAsyncSetupComplete<IScopeLoadAsyncListener>(listener => listener.OnLoadedAsync(), 4000);

            AddDispose<IScopeDisableListener>(listener => listener.OnDisabled(), 0);
            AddAsyncDispose<IScopeDisableAsyncListener>(listener => listener.OnDisabledAsync(), 1000);
            
            return;

            void AddConstruct<T>(Action<T> invoker, int order)
            {
                callbacks.AddScopeCallback(invoker, CallbackStage.Construct, order);
            }
            
            void AddAsyncConstruct<T>(Func<T, UniTask> invoker, int order)
            {
                callbacks.AddScopeAsyncCallback(invoker, CallbackStage.Construct, order);
            }
            
            void AddSetupComplete<T>(Action<T> invoker, int order)
            {
                callbacks.AddScopeCallback(invoker, CallbackStage.SetupComplete, order);
            }
            
            void AddAsyncSetupComplete<T>(Func<T, UniTask> invoker, int order)
            {
                callbacks.AddScopeAsyncCallback(invoker, CallbackStage.SetupComplete, order);
            }
            
            void AddDispose<T>(Action<T> invoker, int order)
            {
                callbacks.AddScopeCallback(invoker, CallbackStage.Dispose, order);
            }
            
            void AddAsyncDispose<T>(Func<T, UniTask> invoker, int order)
            {
                callbacks.AddScopeAsyncCallback(invoker, CallbackStage.Dispose, order);
            }
        }
    }
}