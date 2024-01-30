using System.Collections.Generic;

namespace Common.Architecture.Entities.Runtime
{
    public interface IEntityConfig
    {
        EntitySetupView Prefab { get; }

        IReadOnlyList<IComponentFactory> Components { get; }
    }
}