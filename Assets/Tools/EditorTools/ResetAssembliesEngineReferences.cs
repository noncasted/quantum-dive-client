using Tools.AssembliesViewer.Services.DomainProvider.Runtime;
using UnityEditor;

namespace Tools.EditorTools
{
    public static class ResetAssembliesEngineReferences
    {
        [MenuItem("Tools/Assemblies/Reset engine references")]
        private static void RemoveInvalidAssemblyReferences()
        {
            var domainConstructor = new DomainConstructor();
            var assemblies = domainConstructor.Construct();

            foreach (var assembly in assemblies)
            {
                if (assembly.Details.IsOwned == false)
                    continue;

                if (ContainsEngineReferences() == true)
                    assembly.Toggles.NoEngineReferences = true;

                assembly.Write();

                continue;

                bool ContainsEngineReferences()
                {
                    foreach (var usingLine in assembly.Details.Usings)
                    {
                        if (usingLine.Contains("UnityEngine") || usingLine.Contains("UnityEditor"))
                            return true;
                    }

                    return true;
                }
            }
        }
    }
}