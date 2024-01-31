using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    public interface IEquipmentFactory
    {
        UniTask<IEquipment> Create(IEquipmentInstanceConfig config);
    }
}