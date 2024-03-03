using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Factory.Logs
{
    public class EnemyFactoryLogger
    {
        public EnemyFactoryLogger(IGlobalLogger logger, EnemyFactoryLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly EnemyFactoryLogSettings _settings;

        public void OnLocal(string name, Vector2 position)
        {
            if (_settings.IsAvailable(EnemyFactoryLogType.Local) == false)
                return;

            _logger.Log($"Local enemy: {name} spawned: {position}", _settings.LogParameters);
        }
        
        public void OnRemote(string name, Vector2 position)
        {
            if (_settings.IsAvailable(EnemyFactoryLogType.Local) == false)
                return;

            _logger.Log($"Remote enemy: {name} spawned: {position}", _settings.LogParameters);
        }
    }
}