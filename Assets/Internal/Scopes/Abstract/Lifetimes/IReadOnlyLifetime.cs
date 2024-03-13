using System;
using Cysharp.Threading.Tasks;

namespace Internal.Scopes.Abstract.Lifetimes
{
    public interface IReadOnlyLifetime
    {
        bool IsTerminated { get; }
        
        void ListenTerminate(Action callback);
        void ListenTerminate(Func<UniTask> callback);
    }
}