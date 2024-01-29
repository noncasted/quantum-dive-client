using System.Collections.Generic;
using GamePlay.Player.Entity.Equipment.Abstract.Factory;

namespace GamePlay.Player.Services.Registries.Equipment.Runtime
{
    public class EquipmentRegistry : IEquipmentRegistry
    {
        public EquipmentRegistry(EquipmentFactory[] factories)
        {
            var length = factories.Length;

            var factoriesDictionary = new Dictionary<int, IEquipmentFactory>();
            var idsDictionary = new Dictionary<IEquipmentFactory, int>();
            
            for (var i = 0; i < length; i++)
            {
                var factory = factories[i];
                factoriesDictionary.Add(i, factory);
                idsDictionary.Add(factory, i);
            }

            _factories = factoriesDictionary;
            _ids = idsDictionary;
        }

        private readonly IReadOnlyDictionary<int, IEquipmentFactory> _factories;
        private readonly IReadOnlyDictionary<IEquipmentFactory, int> _ids;

        public int GetId(IEquipmentFactory factory)
        {
            return _ids[factory];
        }

        public IEquipmentFactory GetFactory(int id)
        {
            return _factories[id];
        }
    }
}