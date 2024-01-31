using System.Collections.Generic;
using Features.GamePlay.Player.Entity.Components.Equipment.Definition;

namespace GamePlay.Player.Services.Registries.Equipment.Runtime
{
    public class EquipmentRegistry : IEquipmentRegistry
    {
        public EquipmentRegistry(EquipmentConfig[] factories)
        {
            var length = factories.Length;

            var factoriesDictionary = new Dictionary<int, IEquipmentConfig>();
            var idsDictionary = new Dictionary<IEquipmentConfig, int>();
            
            for (var i = 0; i < length; i++)
            {
                var factory = factories[i];
                factoriesDictionary.Add(i, factory);
                idsDictionary.Add(factory, i);
            }

            _factories = factoriesDictionary;
            _ids = idsDictionary;
        }

        private readonly IReadOnlyDictionary<int, IEquipmentConfig> _factories;
        private readonly IReadOnlyDictionary<IEquipmentConfig, int> _ids;

        public int GetId(IEquipmentConfig config)
        {
            return _ids[config];
        }

        public IEquipmentConfig GetFactory(int id)
        {
            return _factories[id];
        }
    }
}