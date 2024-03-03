using System;
using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.Architecture.Entities.Runtime.Callbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Entities.Common.DefaultCallbacks
{
    public class DefaultCallbacksFactory : IEntityCallbacks, ICallbackRegistry
    {
        private readonly IEntityCallbacksRegistry _callbacksRegistry;
        private readonly IEntityUtils _utils;

        private readonly List<IEntitySwitchLifetimeListener> _switchLifetimeListeners = new();

        public DefaultCallbacksFactory(IEntityCallbacksRegistry callbacksRegistry, IEntityUtils utils)
        {
            _callbacksRegistry = callbacksRegistry;
            _utils = utils;
        }
        
        public void Listen(object listener)
        {
            if (listener is IEntitySwitchLifetimeListener switchLifetimeListener)
                _switchLifetimeListeners.Add(switchLifetimeListener);
        }

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
        public void AddCallbacks()
        {
            _callbacksRegistry.AddGenericCallbackRegistry(this);
            
            AddConstruct<IEntityAwakeListener>(listener => listener.OnAwake(), 0);
            AddAsyncConstruct<IEntityAwakeAsyncListener>(listener => listener.OnAwakeAsync(), 1000);
            AddConstruct<IEntityLifetimeListener>(listener => listener.OnLifetimeCreated(_utils.Lifetime), 3000);

            AddEnable<IEntityEnableListener>(listener => listener.OnEnabled(), 0);
            AddAsyncEnable<IEntityEnableAsyncListener>(listener => listener.OnEnabledAsync(), 1000);

            AddDisable<IEntityDisableListener>(listener => listener.OnDisabled(), 0);
            AddAsyncDisable<IEntityDisableAsyncListener>(listener => listener.OnDisabledAsync(), 1000);

            AddDispose<IEntityDestroyListener>(listener => listener.OnDestroyed(), 0);
            AddAsyncDispose<IEntityDestroyAsyncListener>(listener => listener.OnDestroyedAsync(), 1000);

            return;

            void AddConstruct<T>(Action<T> invoker, int order)
            {
                _callbacksRegistry.AddScopeCallback(invoker, CallbackStage.Construct, order);
            }

            void AddAsyncConstruct<T>(Func<T, UniTask> invoker, int order)
            {
                _callbacksRegistry.AddScopeAsyncCallback(invoker, CallbackStage.Construct, order);
            }

            void AddEnable<T>(Action<T> invoker, int order)
            {
                _callbacksRegistry.AddScopeCallback(invoker, CallbackStage.Enable, order);
            }

            void AddAsyncEnable<T>(Func<T, UniTask> invoker, int order)
            {
                _callbacksRegistry.AddScopeAsyncCallback(invoker, CallbackStage.Enable, order);
            }

            void AddDisable<T>(Action<T> invoker, int order)
            {
                _callbacksRegistry.AddScopeCallback(invoker, CallbackStage.Disable, order);
            }

            void AddAsyncDisable<T>(Func<T, UniTask> invoker, int order)
            {
                _callbacksRegistry.AddScopeAsyncCallback(invoker, CallbackStage.Disable, order);
            }

            void AddDispose<T>(Action<T> invoker, int order)
            {
                _callbacksRegistry.AddScopeCallback(invoker, CallbackStage.Dispose, order);
            }

            void AddAsyncDispose<T>(Func<T, UniTask> invoker, int order)
            {
                _callbacksRegistry.AddScopeAsyncCallback(invoker, CallbackStage.Dispose, order);
            }
        }

        public UniTask RunConstruct()
        {
            return _callbacksRegistry.Handlers[CallbackStage.Construct].Run();
        }
        
        public UniTask RunEnable(ILifetime lifetime)
        {
            foreach (var listener in _switchLifetimeListeners)
                listener.OnSwitchLifetimeCreated(lifetime);
            
            return _callbacksRegistry.Handlers[CallbackStage.Enable].Run();
        }

        public UniTask RunDisable()
        {
            return _callbacksRegistry.Handlers[CallbackStage.Disable].Run();
        }

        public UniTask RunDispose()
        {
            return _callbacksRegistry.Handlers[CallbackStage.Dispose].Run();
        }
    }
}