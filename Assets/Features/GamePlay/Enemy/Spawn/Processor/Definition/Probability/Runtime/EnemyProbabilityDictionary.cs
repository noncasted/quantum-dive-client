using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using GamePlay.Enemy.Entity.Definition.Asset;

namespace GamePlay.Enemy.Spawn.Processor.Definition.Probability.Runtime
{
    [Serializable]
    public class EnemyProbabilityDictionary : SerializableDictionary<EnemyDefinition, float>
    {
    }
}