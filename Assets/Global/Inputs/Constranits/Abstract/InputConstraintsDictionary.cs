using System;
using System.Collections.Generic;
using Common.DataTypes.Runtime.Collections;
using Global.Inputs.Constranits.Definition;

namespace Global.Inputs.Constranits.Abstract
{
    [Serializable]
    public class InputConstraintsDictionary : ReadOnlyDictionary<InputConstraints, bool>
    {
        public IReadOnlyDictionary<InputConstraints, bool> Value => this;
    }
}