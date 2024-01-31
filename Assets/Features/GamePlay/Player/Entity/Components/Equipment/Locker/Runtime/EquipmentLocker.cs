namespace GamePlay.Player.Entity.Components.Equipment.Locker.Runtime
{
    public class EquipmentLocker : IEquipmentLocker
    {
        private bool _isLocked;

        public bool IsLocked => _isLocked;

        public void Lock()
        {
            _isLocked = true;
        }

        public void Unlock()
        {
            _isLocked = false;
        }
    }
}