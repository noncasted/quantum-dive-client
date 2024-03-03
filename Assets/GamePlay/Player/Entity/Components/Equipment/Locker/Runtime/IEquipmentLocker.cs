namespace GamePlay.Player.Entity.Components.Equipment.Locker.Runtime
{
    public interface IEquipmentLocker
    {
        bool IsLocked { get; }
        void Lock();
        void Unlock();
    }
}