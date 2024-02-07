using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Enemy.Entity.Views.Animators.Logs
{
    [Serializable]
    public class AnimatorLogs : ReadOnlyDictionary<AnimatorLogType, bool>
    {
    }
}