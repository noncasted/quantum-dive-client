using System;
using System.Collections.Generic;

namespace Common.Tools.EditorTools
{
    [Serializable]
    public class AsmdefFile
    {
        public string name;
        public List<string> references = new();
    }
}