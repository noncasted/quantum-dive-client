using Internal.Services.Loggers.Runtime;

namespace GamePlay.Loop.Logs
{
    public class LevelLoopLogger
    {
        public LevelLoopLogger(IGlobalLogger logger, LevelLoopLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly LevelLoopLogSettings _settings;

        public void OnLoaded()
        {
            if (_settings.IsAvailable(LevelLoopLogType.Loaded) == false)
                return;

            _logger.Log("Loaded", _settings.LogParameters);
        }
    }
}