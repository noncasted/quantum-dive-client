using System;

namespace Internal.Scopes.Abstract.Lifetimes
{
    public interface IReadOnlyLifetime
    {
        bool IsTerminated { get; }
        
        void ListenTerminate(Action callback);
    }
}