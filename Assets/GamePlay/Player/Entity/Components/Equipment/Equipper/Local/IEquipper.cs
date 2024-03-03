using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Local
{
    public interface IEquipper
    {
        UniTask Equip(IEquipmentConfig config);
    }
}