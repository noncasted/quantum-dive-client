using GamePlay.Enemies.Entity.Definition.Asset;

namespace GamePlay.Enemies.Spawn.Processor.Runtime
{
    public readonly struct EnemyEntry
    {
        public EnemyEntry(EnemyDefinition definition, float density)
        {
            Definition = definition;
            Density = density;
        }
        
        public readonly EnemyDefinition Definition;
        public readonly float Density;
    }
}