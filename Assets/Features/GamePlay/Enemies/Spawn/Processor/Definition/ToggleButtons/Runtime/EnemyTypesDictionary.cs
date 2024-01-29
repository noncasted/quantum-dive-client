using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;

namespace GamePlay.Enemies.Spawn.Processor.Definition.ToggleButtons.Runtime
{
    [Serializable]
    public class EnemyTypesDictionary : SerializableDictionary<EnemyDefinition, bool>
    {
    }
}