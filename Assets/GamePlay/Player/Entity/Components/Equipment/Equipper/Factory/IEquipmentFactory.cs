using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    public interface IEquipmentFactory
    {
        UniTask<IEquipment> Create(IEquipmentInstanceConfig config, SlotDefinition slotDefinition);
    }
}