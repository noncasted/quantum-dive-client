using Internal.Loggers.Runtime;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Logs
{
    public class LocalRotationLogger
    {
        public LocalRotationLogger(IGlobalLogger logger, LocalRotationLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly LocalRotationLogSettings _settings;

        public void OnRotationUsed(float angle)
        {
            if (_settings.IsAvailable(LocalRotationLogType.Use) == false)
                return;

            _logger.Log($"Used: {angle}", _settings.LogParameters);
        }

        public void OnRotationSet(float angle)
        {
            if (_settings.IsAvailable(LocalRotationLogType.Set) == false)
                return;

            _logger.Log($"Set: {angle}", _settings.LogParameters);
        }

        public void OnSpriteRotated(float angle)
        {
            if (_settings.IsAvailable(LocalRotationLogType.SpriteRotate) == false)
                return;

            _logger.Log($"Sprite rotation: {angle}", _settings.LogParameters);
        }

        public void OnAnimatorRotated(float angle)
        {
            if (_settings.IsAvailable(LocalRotationLogType.AnimatorRotate) == false)
                return;

            _logger.Log($"Animator rotation: {angle}", _settings.LogParameters);
        }
    }
}