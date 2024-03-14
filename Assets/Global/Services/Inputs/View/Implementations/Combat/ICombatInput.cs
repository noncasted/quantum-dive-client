using Common.DataTypes.Reactive;

namespace Global.Inputs.View.Implementations.Combat
{
    public interface ICombatInput
    {
        IViewableDelegate RangeAttackPerformed { get; }
        IViewableDelegate RangeAttackCanceled { get; }

        IViewableDelegate MeleeAttackPerformed { get; }
        IViewableDelegate MeleeAttackCanceled { get; }
    }
}