using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using GamePlay.Enemy.Entity.Definition.Asset;

namespace GamePlay.Enemy.Spawn.Processor.Definition.ToggleButtons.Runtime
{
    [Serializable]
    public class EnemyTypesDictionary : SerializableDictionary<EnemyDefinition, bool>
    {
    }
}