namespace GamePlay.Player.Entity.Components.Equipment.Locker.Abstract
{
    public interface IEquipmentLocker
    {
        bool IsLocked { get; }
        void Lock();
        void Unlock();
    }
}