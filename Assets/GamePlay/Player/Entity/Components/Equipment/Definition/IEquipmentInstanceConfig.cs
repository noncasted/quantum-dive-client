
using Internal.Scopes.Abstract.Instances.Entities;

namespace GamePlay.Player.Entity.Components.Equipment.Definition
{
    public interface IEquipmentInstanceConfig : IScopedEntityConfig
    {
        EquipmentViewFactory Prefab { get; }
    }
}