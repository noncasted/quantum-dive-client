using Internal.Loggers.Runtime;

namespace Global.GameLoops.Logs
{
    public class GameLoopLogger
    {
        public GameLoopLogger(IGlobalLogger logger, GameLoopLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly GameLoopLogSettings _settings;

        public void OnBegin()
        {
            if (_settings.IsAvailable(GameLoopLogType.Begin) == false)
                return;

            _logger.Log("Begin", _settings.LogParameters);
        }

        public void OnLoadLevel()
        {
            if (_settings.IsAvailable(GameLoopLogType.LoadLevel) == false)
                return;

            _logger.Log("Level loading started", _settings.LogParameters);
        }

        public void OnLoadMenu()
        {
            if (_settings.IsAvailable(GameLoopLogType.LoadMenu) == false)
                return;

            _logger.Log("Load menu", _settings.LogParameters);
        }
    }
}