using System.Collections.Generic;
using GamePlay.Combat.Projectiles.Registry.Definition;

namespace GamePlay.Combat.Projectiles.Registry.Runtime
{
    public class ProjectileDefinitionsRegistry : IProjectileDefinitionsRegistry
    {
        public ProjectileDefinitionsRegistry(IReadOnlyList<IProjectileDefinition> definitions)
        {
            var length = definitions.Count;

            var definitionsDictionary = new Dictionary<int, IProjectileDefinition>();
            var idsDictionary = new Dictionary<IProjectileDefinition, int>();
            
            for (var i = 0; i < length; i++)
            {
                var definition = definitions[i];
                definitionsDictionary.Add(i, definition);
                idsDictionary.Add(definition, i);
            }

            _definitions = definitionsDictionary;
            _ids = idsDictionary;
        }

        private readonly IReadOnlyDictionary<int, IProjectileDefinition> _definitions;
        private readonly IReadOnlyDictionary<IProjectileDefinition, int> _ids;

        public int GetId(IProjectileDefinition definition)
        {
            return _ids[definition];
        }

        public IProjectileDefinition GetDefinition(int id)
        {
            return _definitions[id];
        }
    }
}