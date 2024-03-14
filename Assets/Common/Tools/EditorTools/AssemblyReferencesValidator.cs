using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Common.Tools.EditorTools
{
    public class AssemblyReferencesValidator
    {
        private static string _sourcesFolder => Application.dataPath + "/GamePlay";

        [MenuItem("Tools/Convert Runtime to Abstract")]
        private static void RemoveInvalidAssemblyReferences()
        {
            var assemblies = GetAllAssemblies();
            var namespaceToAssembly = GetNamespacesToAssembly(assemblies);

            foreach (var asmdef in assemblies)
            {
                var currentReferences = new Dictionary<string, string>();

                foreach (var reference in asmdef.References)
                    currentReferences.Add(reference.AssetPath, reference.Guid);

                foreach (var asmdefNamespace in asmdef.Namespaces)
                    currentReferences.Remove(namespaceToAssembly[asmdefNamespace]);

                var jsonContent = File.ReadAllText(asmdef.FilePath);

                foreach (var (path, guid) in currentReferences)
                    jsonContent = jsonContent.Replace($"{guid},", "").Replace($",\n{guid}", "");

                File.WriteAllText(asmdef.FilePath, jsonContent);
            }
        }

        private static Dictionary<string, string> GetNamespacesToAssembly(Asmdef[] asmdefs)
        {
            var namespaceToAssembly = new Dictionary<string, string>();

            foreach (var assembly in asmdefs)
            {
                foreach (var assemblyNamespace in assembly.Namespaces)
                    namespaceToAssembly.TryAdd(assemblyNamespace, assembly.FilePath);
            }

            return namespaceToAssembly;
        }

        private static Asmdef[] GetAllAssemblies()
        {
            var directories = new string[]
            {
                Application.dataPath + "/Common",
                Application.dataPath + "/GamePlay",
                Application.dataPath + "/Global",
                Application.dataPath + "/Internal"
            };

            var asmdefs = new List<Asmdef>();

            foreach (var directory in directories)
                asmdefs.AddRange(GetDirectoryAssemblies(directory));

            return asmdefs.ToArray();
        }

        private static Asmdef[] GetDirectoryAssemblies(string path)
        {
            var asmdefsPaths = Directory.GetFiles(path, "*.asmdef", SearchOption.AllDirectories);
            var asmdefs = new List<Asmdef>();

            foreach (var asmdefsPath in asmdefsPaths)
                asmdefs.Add(GetAssembly(asmdefsPath));

            return asmdefs.ToArray();

            Asmdef GetAssembly(string asmdefPath)
            {
                var directory = GetParentDirectory(asmdefPath);
                var codeFiles = Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories);

                var namespaces = new List<string>();
                var usings = new List<string>();

                foreach (var filePath in codeFiles)
                {
                    var fileNamespace = GetNameSpace(filePath);
                    var fileUsings = GetUsings(filePath);
                    usings.AddRange(fileUsings);

                    if (fileNamespace == string.Empty)
                        continue;

                    namespaces.Add(fileNamespace);
                }

                return new Asmdef()
                {
                    Directory = directory,
                    FilePath = asmdefPath,
                    Namespaces = namespaces.ToArray(),
                    Usings = usings.ToArray(),
                    References = GetReferences(asmdefPath)
                };
            }

            string GetNameSpace(string filePath)
            {
                var text = File.ReadLines(filePath);

                foreach (var line in text)
                {
                    if (line.Contains("namespace") == false)
                        continue;

                    var fileNamespace = line.Replace("namespace ", "");
                    return fileNamespace;
                }

                return string.Empty;
            }

            string[] GetUsings(string filePath)
            {
                var lines = File.ReadLines(filePath);
                var rawUsings = new List<string>();

                foreach (var line in lines)
                {
                    if (line.Contains("using") == false)
                        return rawUsings.ToArray();

                    var fileUsing = line.Replace("using ", "").Replace(";", "");
                    rawUsings.Add(fileUsing);
                }

                return rawUsings.ToArray();
            }

            AsmdefReference[] GetReferences(string filePath)
            {
                var jsonContent = File.ReadAllText(filePath);
                var asmdef = JsonConvert.DeserializeObject<AsmdefFile>(jsonContent);

                if (asmdef.references.Count == 0)
                    return Array.Empty<AsmdefReference>();

                var references = new List<AsmdefReference>();

                foreach (var referenceGUID in asmdef.references)
                {
                    var reference = referenceGUID.Replace("GUID:", "");

                    var assetPath = AssetDatabase.GUIDToAssetPath(reference);

                    if (assetPath != string.Empty)
                        continue;

                    references.Add(new AsmdefReference()
                    {
                        AssetPath = assetPath,
                        Guid = referenceGUID
                    });
                }

                return references.ToArray();
            }
        }

        private static string GetParentDirectory(string source)
        {
            var remove = source.Split("/")[^1];
            var length = remove.Length;
            return source.Remove(source.Length - length, length);
        }

        private static string[] ConvertToUnifiedPath(string[] sources)
        {
            var result = new string[sources.Length];

            for (var i = 0; i < sources.Length; i++)
                result[i] = ConvertToUnifiedPath(sources[i]);

            return result;
        }

        private static string ConvertToUnifiedPath(string source)
        {
            return source.Replace("\\", "/");
        }

        public class Asmdef
        {
            public string FilePath { get; set; }
            public string Directory { get; set; }
            public string[] Namespaces { get; set; }
            public string[] Usings { get; set; }
            public AsmdefReference[] References { get; set; }
        }

        public class AsmdefReference
        {
            public string AssetPath { get; set; }
            public string Guid { get; set; }
        }
    }
}