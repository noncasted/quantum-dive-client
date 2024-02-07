using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using GamePlay.Enemies.Entity.Definition.Asset;

namespace GamePlay.Enemies.Spawn.Processor.Definition.Probability.Runtime
{
    [Serializable]
    public class ProbabilityDictionary : SerializableDictionary<EnemyDefinition, float>
    {
    }
}