using GamePlay.Player.Entity.Equipment.Abstract.Factory;

namespace GamePlay.Player.Services.Registries.Equipment.Runtime
{
    public interface IEquipmentRegistry
    {
        int GetId(IEquipmentConfig config);
        IEquipmentConfig GetFactory(int id);
    }
}