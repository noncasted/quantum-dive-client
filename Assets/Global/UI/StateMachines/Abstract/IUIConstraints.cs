using System.Collections.Generic;
using Global.Inputs.Constranits.Definition;

namespace Global.UI.StateMachines.Abstract
{
    public interface IUIConstraints
    {
        IReadOnlyDictionary<InputConstraints, bool> Input { get; }
    }
}