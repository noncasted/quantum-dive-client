using System;
using Internal.Scopes.Abstract.Lifetimes;

namespace Internal.Scopes.Runtime.Lifetimes
{
    public class TerminatedLifetime : ILifetime
    {
        public bool IsTerminated => true;
        
        public void ListenTerminate(Action callback)
        {
        }

        public void Terminate()
        {
        }
    }
}