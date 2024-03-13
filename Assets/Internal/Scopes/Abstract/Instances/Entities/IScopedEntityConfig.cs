using System.Collections.Generic;

namespace Internal.Scopes.Abstract.Instances.Entities
{
    public interface IScopedEntityConfig
    {
        IScopedEntityViewFactory Prefab { get; }

        IReadOnlyList<IComponentFactory> Components { get; }
        IReadOnlyList<IComponentsCompose> Composes { get; }
    }
}