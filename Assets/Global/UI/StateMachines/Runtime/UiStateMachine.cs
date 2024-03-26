using System.Collections.Generic;
using Global.Inputs.Constranits.Abstract;
using Global.UI.StateMachines.Abstract;

namespace Global.UI.StateMachines.Runtime
{
    public class UiStateMachine : IUiStateMachine
    {
        public UiStateMachine(IInputConstraintsStorage constraintsStorage)
        {
            _constraintsStorage = constraintsStorage;
        }

        private readonly IInputConstraintsStorage _constraintsStorage;

        private readonly Dictionary<IUiState, StateHandle> _handles = new();
        private readonly Stack<StateHandle> _stack = new();

        private IUiState _head;

        public void EnterAsSingle(IUiState state)
        {
            if (_stack.Count != 0)
            {
                var current = _stack.Peek();

                current.Exit(false);
            }

            var handle = new StateHandle(state, null, OnStackExited, OnStackRecovered);
            _stack.Push(handle);

            if (_handles.ContainsKey(state) == true)
                _handles.Remove(state);

            _handles.Add(state, handle);

            _head = state;

            _constraintsStorage.Add(state.Constraints.Input);
        }

        public void EnterAsStack(IUiState head, IUiState state)
        {
            var handle = new StateHandle(state, _handles[head], OnStackExited, OnStackRecovered);

            _handles[head].AddToStack(handle);

            _constraintsStorage.Add(state.Constraints.Input);
        }

        public void EnterAsStack(IUiState state)
        {
            var handle = new StateHandle(state, _handles[_head], OnStackExited, OnStackRecovered);

            _handles[_head].AddToStack(handle);
            _handles[state] = handle;

            _constraintsStorage.Add(state.Constraints.Input);
        }

        public void Exit(IUiState state, bool withDispose = true)
        {
            if (_handles.ContainsKey(state) == false)
                return;

            _handles[state].Exit(withDispose);
            _handles.Remove(state);

            if (state != _head)
                return;

            var head = _stack.Pop();

            _head = null;

            if (_stack.Count == 0)
                return;

            var previous = _stack.Peek();
            previous.Recover();
            _head = previous.State;
        }

        private void OnStackExited(IUiState state)
        {
            _constraintsStorage.Remove(state.Constraints.Input);
        }

        private void OnStackRecovered(StateHandle handle)
        {
            _constraintsStorage.Add(handle.State.Constraints.Input);
        }
    }
}