using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.LevelCameras.Logs
{
    [Serializable]
    public class LevelCameraLogs : ReadOnlyDictionary<LevelCameraLogType, bool>
    {
    }
}