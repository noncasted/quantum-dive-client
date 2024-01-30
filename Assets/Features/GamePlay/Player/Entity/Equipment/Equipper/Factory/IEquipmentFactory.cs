using Cysharp.Threading.Tasks;
using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;

namespace Features.GamePlay.Player.Entity.Equipment.Equipper.Factory
{
    public interface IEquipmentFactory
    {
        UniTask<IEquipment> Create(IEquipmentInstanceConfig config);
    }
}