using System.Collections.Generic;
using Tools.AssembliesViewer.Domain.Abstract;

namespace Tools.AssembliesViewer.Domain.Runtime
{
    public class Assembly : IAssembly
    {
        public Assembly(
            string fileName,
            string name,
            string fullPathName,
            string id,
            IReadOnlyList<IAssembly> references,
            IAssemblyDetails details)
        {
            DirectoryName = fileName;
            Name = name;
            FullPathName = fullPathName;
            Id = id;
            References = references;
            Details = details;
        }

        public string DirectoryName { get; }
        public string Name { get; }
        public string FullPathName { get; }
        public string Id { get; }
        public IReadOnlyList<IAssembly> References { get; }
        public IAssemblyDetails Details { get; }
    }
}