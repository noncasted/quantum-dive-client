using System;
using System.Collections.Generic;
using Common.Architecture.Callbacks;
using Common.Architecture.Container.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Scopes.Runtime.Callbacks
{
    public class ScopeCallbacks : IScopeCallbacks
    {
        private readonly Dictionary<CallbackStage, ICallbacksHandler> _callbacks = new();
        private readonly List<ICallbackRegistry> _genericRegisters = new();

        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Handlers => _callbacks;

        public void Listen(object listener)
        {
            foreach (var (_, handler) in _callbacks)
                handler.Listen(listener);

            foreach (var register in _genericRegisters)
                register.Listen(listener);
        }

        public void AddScopeCallback<T>(Action<T> invoker, CallbackStage stage, int order)
        {
            if (_callbacks.ContainsKey(stage) == false)
                _callbacks.Add(stage, new CallbacksHandler());

            var entity = new CallbackEntity<T>(invoker, order);
            _callbacks[stage].Add(entity);
        }

        public void AddScopeAsyncCallback<T>(Func<T, UniTask> invoker, CallbackStage stage, int order)
        {
            if (_callbacks.ContainsKey(stage) == false)
                _callbacks.Add(stage, new CallbacksHandler());
            
            var entity = new AsyncCallbackEntity<T>(invoker, order);
            _callbacks[stage].Add(entity);
        }

        public void AddGenericCallbackRegister(ICallbackRegistry callbackRegistry)
        {
            _genericRegisters.Add(callbackRegistry);
        }
    }
}