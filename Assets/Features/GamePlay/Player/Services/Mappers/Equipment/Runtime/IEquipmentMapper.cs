using GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Mappers.Equipment.Runtime
{
    public interface IEquipmentMapper
    {
        int GetId(IEquipmentConfig config);
        IEquipmentConfig GetFactory(int id);
    }
}