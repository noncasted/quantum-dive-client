namespace GamePlay.Player.Entity.Weapons.Common.SlotLocker.Runtime
{
    public interface IEquipmentSlotLocker
    {
        bool IsLocked { get; }
        
        void Lock();
        void Unlock();
    }
}