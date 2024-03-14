using System.Collections.Generic;
using Internal.Abstract;
using Internal.Services.Options.Runtime;

namespace Internal.Runtime
{
    public interface IInternalScopeConfig
    {
        InternalScope Scope { get; }
        Options Options { get; }
        IReadOnlyList<IInternalServiceFactory> Services { get; }
    }
}