    using System;

    namespace Global.Inputs.View.Implementations.Combat
    {
        public interface ICombatInput
        {
            event Action RangeAttackPerformed;
            event Action RangeAttackCanceled;
        
            event Action MeleeAttackPerformed;
            event Action MeleeAttackCanceled;
        }
    }