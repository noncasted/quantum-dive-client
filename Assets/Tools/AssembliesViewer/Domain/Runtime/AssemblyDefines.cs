using System;
using System.Collections.Generic;
using Tools.AssembliesViewer.Domain.Abstract;

namespace Tools.AssembliesViewer.Domain.Runtime
{
    public class AssemblyDefines : IAssemblyDefines
    {
        public AssemblyDefines(
            List<string> includePlatforms,
            List<string> excludePlatforms,
            List<string> precompiledReferences,
            List<string> defineConstraints,
            List<string> versionDefines
        )
        {
            IncludePlatforms = includePlatforms;
            ExcludePlatforms = excludePlatforms;
            PrecompiledReferences = precompiledReferences;
            DefineConstraints = defineConstraints;
            VersionDefines = versionDefines;
        }


        public List<string> IncludePlatforms { get; }
        public List<string> ExcludePlatforms { get; set; }
        public List<string> PrecompiledReferences { get; set; }
        public List<string> DefineConstraints { get; set; }
        public List<string> VersionDefines { get; set; }

        public override string ToString()
        {
            var value = string.Empty;

            value += ListToString("includePlatforms", IncludePlatforms);
            value += ListToString("excludePlatforms", IncludePlatforms);
            value += ListToString("precompiledReferences", IncludePlatforms);
            value += ListToString("defineConstraints", IncludePlatforms);
            value += ListToString("versionDefines", IncludePlatforms);

            return value;
        }

        public string ListToString(string header, IReadOnlyList<string> list)
        {
            var newLine = Environment.NewLine;
            var value = $"{newLine}    \"{header}\": [";

            for (var i = 0; i < list.Count; i++)
            {
                value += $",{newLine}    \"{list[i]}\"";

                if (i != list.Count - 1)
                    value += $",{newLine}";
            }

            value += $"{newLine}    ]";

            return value;
        }
    }
}