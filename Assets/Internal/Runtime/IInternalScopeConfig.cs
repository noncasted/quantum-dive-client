using System.Collections.Generic;
using Internal.Abstract;

namespace Internal.Scope
{
    public interface IInternalScopeConfig
    {
        InternalScope Scope { get; }
        Options.Runtime.Options Options { get; }
        IReadOnlyList<IInternalServiceFactory> Services { get; }
    }
}