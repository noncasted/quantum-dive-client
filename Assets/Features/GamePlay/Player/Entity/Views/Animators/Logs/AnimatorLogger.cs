using Internal.Services.Loggers.Runtime;

namespace GamePlay.Player.Entity.Views.Animators.Logs
{
    public class AnimatorLogger
    {
        public AnimatorLogger(IGlobalLogger logger, AnimatorLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly AnimatorLogSettings _settings;

        public void OnLooped(string name)
        {
            if (_settings.IsAvailable(AnimatorLogType.Looped) == false)
                return;

            _logger.Log($"Play loop animation: {name}", _settings.LogParameters);
        }

        public void OnAsync(string name)
        {
            if (_settings.IsAvailable(AnimatorLogType.Async) == false)
                return;

            _logger.Log($"Play async animation: {name}", _settings.LogParameters);
        }
    }
}