using Tools.AssembliesViewer.Services.DomainProvider.Runtime;
using UnityEditor;

namespace Tools.EditorTools
{
    public static class RewriteAssemblies
    {
        [MenuItem("Tools/Assemblies/Rewrite")]
        private static void RemoveInvalidAssemblyReferences()
        {
            var domainConstructor = new DomainConstructor();
            var assemblies = domainConstructor.Construct();

            foreach (var assembly in assemblies)
                assembly.Write();
        }
    }
}