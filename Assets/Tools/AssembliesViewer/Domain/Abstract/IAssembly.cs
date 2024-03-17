using System.Collections.Generic;

namespace Tools.AssembliesViewer.Domain.Abstract
{
    public interface IAssembly
    {
        string DirectoryName { get; }
        string Name { get; }
        string FullPathName { get; }
        string Id { get; }
        IReadOnlyList<IAssembly> References { get; }
        IAssemblyDetails Details { get; }
    }
}