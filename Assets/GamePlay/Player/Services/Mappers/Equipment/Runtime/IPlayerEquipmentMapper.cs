using GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Mappers.Equipment.Runtime
{
    public interface IPlayerEquipmentMapper
    {
        int GetId(IEquipmentConfig config);
        IEquipmentConfig GetFactory(int id);
    }
}