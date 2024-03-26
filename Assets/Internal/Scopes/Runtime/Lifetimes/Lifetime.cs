using System;
using System.Collections.Generic;
using Internal.Scopes.Abstract.Lifetimes;

namespace Internal.Scopes.Runtime.Lifetimes
{
    public class Lifetime : ILifetime
    {
        private readonly HashSet<Action> _terminationListeners = new();

        private bool _isTerminated;

        public bool IsTerminated => _isTerminated;

        public void ListenTerminate(Action callback)
        {
            if (_isTerminated == true)
                return;
            
            _terminationListeners.Add(callback);
        }

        public void Terminate()
        {
            _isTerminated = true;
            
            foreach (var listener in _terminationListeners)
                listener.Invoke();
        }
    }
}