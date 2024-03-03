using System;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Lifetimes
{
    public interface ILifetime
    {
        bool IsTerminated { get; }
        
        void ListenTerminate(Action callback);
        void ListenTerminate(Func<UniTask> callback);
        
        UniTask Terminate();
    }
}