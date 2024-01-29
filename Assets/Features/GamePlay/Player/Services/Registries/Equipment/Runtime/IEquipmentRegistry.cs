using GamePlay.Player.Entity.Equipment.Abstract.Factory;

namespace GamePlay.Player.Services.Registries.Equipment.Runtime
{
    public interface IEquipmentRegistry
    {
        int GetId(IEquipmentFactory factory);
        IEquipmentFactory GetFactory(int id);
    }
}