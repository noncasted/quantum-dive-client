using Features.GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Remote
{
    public interface IEquipperSync
    {
        void OnEquipped(IEquipmentConfig equipmentConfig);
    }
}