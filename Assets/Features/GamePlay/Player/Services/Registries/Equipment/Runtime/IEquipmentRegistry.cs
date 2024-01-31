using GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Registries.Equipment.Runtime
{
    public interface IEquipmentRegistry
    {
        int GetId(IEquipmentConfig config);
        IEquipmentConfig GetFactory(int id);
    }
}