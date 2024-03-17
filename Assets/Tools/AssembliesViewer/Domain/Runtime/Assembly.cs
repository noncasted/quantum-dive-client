using System;
using System.Collections.Generic;
using Tools.AssembliesViewer.Domain.Abstract;

namespace Tools.AssembliesViewer.Domain.Runtime
{
    public class Assembly : IAssembly
    {
        public Assembly(
            string name,
            string id,
            IReadOnlyList<IAssembly> references,
            IAssemblyDetails details)
        {
            Name = name;
            Id = id;
            References = references;
            Details = details;
        }

        public string Name { get; }
        public string Id { get; }
        public IReadOnlyList<IAssembly> References { get; }
        public IAssemblyDetails Details { get; }
    }
}