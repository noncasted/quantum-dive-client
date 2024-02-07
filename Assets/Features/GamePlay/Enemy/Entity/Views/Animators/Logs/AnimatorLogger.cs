using Internal.Services.Loggers.Runtime;

namespace GamePlay.Enemy.Entity.Views.Animators.Logs
{
    public class AnimatorLogger
    {
        public AnimatorLogger(ILogger logger, AnimatorLogSettings settings, AnimatorDebugFlag flag)
        {
            _logger = logger;
            _settings = settings;
            _flag = flag;
        }

        private readonly ILogger _logger;
        private readonly AnimatorLogSettings _settings;
        private readonly AnimatorDebugFlag _flag;

        public void OnLooped(string name)
        {
            if (_settings.IsAvailable(AnimatorLogType.Looped) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Play loop animation: {name}", _settings.LogParameters);
        }

        public void OnAsync(string name)
        {
            if (_settings.IsAvailable(AnimatorLogType.Async) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Play async animation: {name}", _settings.LogParameters);
        }
    }
}