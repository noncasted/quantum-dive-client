using System.Collections.Generic;
using Global.Inputs.Constranits.Definition;

namespace Global.UI.UiStateMachines.Runtime
{
    public interface IUIConstraints
    {
        IReadOnlyDictionary<InputConstraints, bool> Input { get; }
    }
}