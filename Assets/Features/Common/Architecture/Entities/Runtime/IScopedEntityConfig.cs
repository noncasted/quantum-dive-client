using System.Collections.Generic;

namespace Common.Architecture.Entities.Runtime
{
    public interface IScopedEntityConfig
    {
        ScopedEntityViewFactory Prefab { get; }

        IReadOnlyList<IComponentFactory> Components { get; }
        IReadOnlyList<IComponentsCompose> Composes { get; }
    }
}