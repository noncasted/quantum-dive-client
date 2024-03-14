﻿using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Common.Tools.EditorTools
{
    public class RuntimeToAbstractConverter
    {
        private static string _sourcesFolder => Application.dataPath + "/GamePlay/Player/UI";

        [MenuItem("Tools/Convert Runtime to Abstract")]
        private static void RemoveInvalidAssemblyReferences()
        {
            var runtimeDirectories = GetAllRuntimeDirectories();

            foreach (var directory in runtimeDirectories)
            {
                directory.Abstract = GetAbstractDirectory(directory.Path);

                MoveInterfacesToAbstract(directory.Interfaces, directory.Abstract);
                CreateAsmdef(directory);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            foreach (var directory in runtimeDirectories)
                AddAbstractReferenceToRuntime(directory);

            var replaceGuid = new Dictionary<string, string>();

            foreach (var directory in runtimeDirectories)
                replaceGuid.Add(directory.RuntimeGuid, directory.AbstractGuid);

            var runtimeAsmdefs = Directory.GetFiles(_sourcesFolder, "*Runtime.asmdef");

            foreach (var runtimePath in runtimeAsmdefs)
            {
                var asmdefContent = File.ReadAllText(runtimePath);

                foreach (var (source, target) in replaceGuid)
                    asmdefContent = asmdefContent.Replace(source, target);

                File.WriteAllText(runtimePath, asmdefContent);
            }
        }

        private static void AddAbstractReferenceToRuntime(ProjectDirectory directory)
        {
            var abstractGuid = AssetDatabase.AssetPathToGUID(directory.AbstractAsmdef);
            var runtimeGuid = AssetDatabase.AssetPathToGUID(directory.RuntimeAsmdef);

            directory.AbstractGuid = abstractGuid;
            directory.RuntimeGuid = runtimeGuid;

            var jsonContent = File.ReadAllText(directory.RuntimeAsmdef);
            var replace = jsonContent.Replace("\"references\": [", $"\"references\": [\"GUID: {abstractGuid},");
            File.WriteAllText(directory.RuntimeAsmdef, replace);
        }

        private static void CreateAsmdef(ProjectDirectory directory)
        {
            var asmdefName = directory.RuntimeAsmdef.Replace("Runtime.asmdef", "Abstract.asmdef");
            var asmdefPath = asmdefName.Replace("Runtime/", "Abstract/");
            File.AppendAllLines(asmdefPath, new[]
            {
                "{",
                $"name: \"{asmdefName.Split("/")[^1]}\"",
                "}"
            });

            directory.AbstractAsmdef = asmdefPath;
        }

        private static void MoveInterfacesToAbstract(string[] interfaces, string abstractDirectory)
        {
            foreach (var file in interfaces)
            {
                var fileName = file.Split("/")[^1];
                File.Move(file, abstractDirectory + $"/{fileName}");
            }
        }

        private static string GetAbstractDirectory(string path)
        {
            var parentDirectory = path.Split("/")[^2];

            var directories = Directory.GetDirectories(parentDirectory, "Abstract");

            if (directories.Length == 0)
                return Directory.CreateDirectory(parentDirectory + "Abstract").FullName;

            return parentDirectory + "/Abstract";
        }

        private static IReadOnlyList<ProjectDirectory> GetAllRuntimeDirectories()
        {
            var directories = new List<ProjectDirectory>();
            var paths = Directory.GetDirectories(_sourcesFolder, "Runtime", SearchOption.AllDirectories);

            foreach (var path in paths)
            {
                var interfaces = Directory.GetFiles(path, "I*.cs");

                if (interfaces.Length == 0)
                    continue;

                var asmdef = Directory.GetFiles(path, "*.asmdef");

                directories.Add(new ProjectDirectory()
                {
                    Path = path,
                    Interfaces = interfaces,
                    RuntimeAsmdef = asmdef[0]
                });
            }

            return directories;
        }

        public class ProjectDirectory
        {
            public string Path;
            public string Abstract;
            public string RuntimeAsmdef;
            public string AbstractAsmdef;
            public string AbstractGuid;
            public string RuntimeGuid;

            public string[] Interfaces;
        }
    }
}