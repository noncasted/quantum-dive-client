using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Services;

namespace Common.Architecture.Scopes.Runtime.Services
{
    public interface IServicesCompose
    {
        IReadOnlyList<IServiceFactory> Factories { get; }
    }
}