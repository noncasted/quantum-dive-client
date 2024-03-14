using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract
{
    public interface IEquipmentSlotsStorage
    {
        UniTask Equip(IEquipment equipment);
    }
}