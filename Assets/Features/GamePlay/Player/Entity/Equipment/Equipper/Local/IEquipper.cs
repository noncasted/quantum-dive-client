using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Abstract.Factory;

namespace GamePlay.Player.Entity.Equipment.Equipper.Local
{
    public interface IEquipper
    {
        UniTask Equip(IEquipmentConfig config);
    }
}