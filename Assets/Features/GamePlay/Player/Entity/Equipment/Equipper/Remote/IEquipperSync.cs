using GamePlay.Player.Entity.Equipment.Abstract.Factory;

namespace GamePlay.Player.Entity.Equipment.Equipper.Remote
{
    public interface IEquipperSync
    {
        void OnEquipped(IEquipmentFactory equipmentFactory);
    }
}