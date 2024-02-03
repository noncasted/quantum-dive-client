using Common.DataTypes.Collections.Common;
using GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Registries.Equipment.Runtime
{
    public class EquipmentRegistry : IEquipmentRegistry
    {
        public EquipmentRegistry(EquipmentConfig[] factories)
        {
            _configs = new DoubleSideIntDictionary<IEquipmentConfig>(factories);
        }


        private readonly IDoubleSideDictionary<int, IEquipmentConfig> _configs;
        public int GetId(IEquipmentConfig config)
        {
            return _configs.Keys[config];
        }

        public IEquipmentConfig GetFactory(int id)
        {
            return _configs.Values[id];
        }
    }
}