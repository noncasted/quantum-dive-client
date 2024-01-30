using Cysharp.Threading.Tasks;
using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;

namespace Features.GamePlay.Player.Entity.Equipment.Equipper.Factory
{
    public interface IEquipmentFactory
    {
        UniTask<IEquipment> Create(IEquipmentInstanceConfig config);
    }
}