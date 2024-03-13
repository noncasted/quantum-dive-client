using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Lifetimes;

namespace Internal.Scopes.Runtime.Lifetimes
{
    public class Lifetime : ILifetime
    {
        private readonly HashSet<Action> _terminationListeners = new();
        private readonly HashSet<Func<UniTask>> _asyncTerminationListeners = new();

        private bool _isTerminated;

        public bool IsTerminated => _isTerminated;

        public void ListenTerminate(Action callback)
        {
            _terminationListeners.Add(callback);
        }

        public void ListenTerminate(Func<UniTask> callback)
        {
            _asyncTerminationListeners.Add(callback);
        }

        public async UniTask Terminate()
        {
            _isTerminated = true;
            
            foreach (var listener in _terminationListeners)
                listener.Invoke();

            var tasks = new UniTask[_asyncTerminationListeners.Count];
            var index = 0;

            foreach (var listener in _asyncTerminationListeners)
            {
                tasks[index] = listener.Invoke();
                index++;
            }

            await UniTask.WhenAll(tasks);
        }
    }
}