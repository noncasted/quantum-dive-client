using Tools.AssembliesViewer.Domain.Abstract;

namespace Tools.AssembliesViewer.Domain.Runtime
{
    public class AssemblyPath : IAssemblyPath
    {
        public AssemblyPath(
            string directoryName,
            string name,
            string fullPathName)
        {
            DirectoryName = directoryName;
            Name = name;
            FullPathName = fullPathName;
        }
        
        public string DirectoryName { get; }
        public string Name { get; }
        public string FullPathName { get; }
    }
}