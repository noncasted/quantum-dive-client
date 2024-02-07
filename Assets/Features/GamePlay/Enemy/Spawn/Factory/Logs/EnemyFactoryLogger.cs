using UnityEngine;

namespace GamePlay.Enemies.Spawn.Factory.Logs
{
    public class EnemyFactoryLogger
    {
        public EnemyFactoryLogger(ILogger logger, EnemyFactoryLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
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