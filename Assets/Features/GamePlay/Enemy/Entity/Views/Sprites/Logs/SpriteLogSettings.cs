using GamePlay.Enemy.Entity.Views.Sprites.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Logs
{
    [CreateAssetMenu(fileName = SpriteViewRoutes.LogsName,
        menuName = SpriteViewRoutes.LogsPath)]
    public class SpriteLogSettings : LogSettings<SpriteLogs, SpriteLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}