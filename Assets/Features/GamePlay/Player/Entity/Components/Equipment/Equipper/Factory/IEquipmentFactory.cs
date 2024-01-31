using Cysharp.Threading.Tasks;
using Features.GamePlay.Player.Entity.Components.Equipment.Definition;

namespace Features.GamePlay.Player.Entity.Components.Equipment.Equipper.Factory
{
    public interface IEquipmentFactory
    {
        UniTask<IEquipment> Create(IEquipmentInstanceConfig config);
    }
}