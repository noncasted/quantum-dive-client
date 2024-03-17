using System;
using System.Collections.Generic;

namespace Tools.AssembliesViewer.Domain.Abstract
{
    public interface IAssembly
    {
        string Name { get; }
        string Id { get; }
        IReadOnlyList<IAssembly> References { get; }
        IAssemblyDetails Details { get; }
    }
}