﻿namespace Global.UI.StateMachines.Abstract
{
    public interface IUiStateMachine
    {
        void EnterAsSingle(IUiState state);
        void EnterAsStack(IUiState head, IUiState state);
        void EnterAsStack(IUiState state);
        void Exit(IUiState state, bool withDispose = true);
    }
}