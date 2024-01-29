namespace Global.Inputs.View.Logs
{
    public enum InputViewLogType
    {
        LeftMouseButtonDown,
        LeftMouseButtonUp,
        RightMouseButtonDown,
        RightMouseButtonUp,
        MouseMoved,

        RollPressed,
        RollCanceled,

        MovementPressed,
        MovementCanceled,

        RangeAttackPerformed,
        RangeAttackCanceled,

        MeleeAttackPerformed,
        MeleeAttackCanceled,

        BeforeRebind,
        AfterRebind,

        ConstraintAdded,
        ConstraintReduced,
        ConstraintRemoved,
        ConstraintBelowZeroException,
        InputCanceledWithConstraint
    }
}