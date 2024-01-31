using System.Collections.Generic;

namespace Common.Architecture.Entities.Runtime
{
    public interface IComponentsCompose
    {
        IReadOnlyList<IComponentFactory> Factories { get; }
    }
}