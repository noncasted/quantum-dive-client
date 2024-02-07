using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Visuals.Cameras.Logs
{
    [Serializable]
    public class LevelCameraLogs : ReadOnlyDictionary<LevelCameraLogType, bool>
    {
    }
}