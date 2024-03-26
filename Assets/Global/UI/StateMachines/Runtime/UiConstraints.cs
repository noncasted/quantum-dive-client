using System.Collections.Generic;
using Global.Inputs.Constranits.Abstract;
using Global.Inputs.Constranits.Definition;
using Global.UI.StateMachines.Abstract;
using Global.UI.StateMachines.Common;
using UnityEngine;

namespace Global.UI.StateMachines.Runtime
{
    [CreateAssetMenu(fileName = UiStateMachineRouter.ConstraintsPrefix,
        menuName = UiStateMachineRouter.ConstraintsPath)]
    public class UiConstraints : ScriptableObject, IUIConstraints
    {
        [SerializeField] private InputConstraintsDictionary _input;

        public IReadOnlyDictionary<InputConstraints, bool> Input => _input.Value;
    }
}