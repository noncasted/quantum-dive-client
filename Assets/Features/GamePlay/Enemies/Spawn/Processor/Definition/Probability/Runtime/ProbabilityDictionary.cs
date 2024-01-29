using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;

namespace GamePlay.Enemies.Spawn.Processor.Definition.Probability.Runtime
{
    [Serializable]
    public class ProbabilityDictionary : SerializableDictionary<EnemyDefinition, float>
    {
    }
}