using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Common.Tools.EditorTools
{
    public class InvalidAssemblyReferencesRemover
    {
        private const string _sourcesFolder = "/Features/";
        
        [MenuItem("Tools/Remove invalid asmdef references")]
        private static void RemoveInvalidAssemblyReferences()
        {
            var directory = Application.dataPath + _sourcesFolder;

            var allAssembliesNames = GetDllAssemblyNames(directory);
            
            
        }
        
        private static IEnumerable<string> GetDllAssemblyNames(string directory)
        {
            return Directory.EnumerateFiles(directory, "*.asmdef", SearchOption.AllDirectories)
                .Distinct()
                .Select(Path.GetFileNameWithoutExtension);
        }
    }
}