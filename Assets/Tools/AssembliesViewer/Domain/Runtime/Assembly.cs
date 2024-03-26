using System.Collections.Generic;
using System.IO;
using Tools.AssembliesViewer.Domain.Abstract;

namespace Tools.AssembliesViewer.Domain.Runtime
{
    public class Assembly : IAssembly
    {
        public Assembly(
            string id,
            IAssemblyPath path,
            List<IAssembly> references,
            IAssemblyDetails details,
            IAssemblyToggles toggles,
            IAssemblyDefines defines)
        {
            _references = references;
            Id = id;
            Path = path;
            Details = details;
            Toggles = toggles;
            Defines = defines;
        }

        private readonly List<IAssembly> _references;

        public string Id { get; }
        public IAssemblyPath Path { get; }
        public IReadOnlyList<IAssembly> References => _references;
        public IAssemblyDetails Details { get; }
        public IAssemblyToggles Toggles { get; }
        public IAssemblyDefines Defines { get; }

        public void AddAssembly(IAssembly assembly)
        {
            _references.Add(assembly);
        }

        public void RemoveReference(IAssembly assembly)
        {
            _references.Remove(assembly);
        }

        public void Write()
        {
            var json =
                "{\n" +
                $"    \"name\": {Path.Name},\n" +
                $"    {ReferencesToString()},\r\n" +
                $"    {Defines.ToString()},\r\n" +
                $"    {Toggles.ToString()}\r\n" +
                "}";
            
            File.WriteAllText(Path.FullPathName, json);
        }

        string ReferencesToString()
        {
            var value = "\"references\": [\n";

            for (var i = 0; i < References.Count; i++)
            {
                value += $",\r\n    \"GUID:{References[i].Id}\"";
                if (i != References.Count - 1)
                    value += ",";
            }

            value += "\r\n    ]";

            return value;
        }
    }
}