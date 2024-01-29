namespace GamePlay.Player.Entity.Equipment.Locker.Runtime
{
    public interface IEquipmentLocker
    {
        bool IsLocked { get; }
        void Lock();
        void Unlock();
    }
}