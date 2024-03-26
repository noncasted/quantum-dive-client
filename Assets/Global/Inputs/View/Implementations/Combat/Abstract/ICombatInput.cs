using Common.DataTypes.Runtime.Reactive;

namespace Global.Inputs.View.Implementations.Combat.Abstract
{
    public interface ICombatInput
    {
        IViewableDelegate RangeAttackPerformed { get; }
        IViewableDelegate RangeAttackCanceled { get; }

        IViewableDelegate MeleeAttackPerformed { get; }
        IViewableDelegate MeleeAttackCanceled { get; }
    }
}