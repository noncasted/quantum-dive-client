using Internal.Loggers.Runtime;

namespace GamePlay.Player.Entity.States.None.Logs
{
    public class NoneLogger
    {
        public NoneLogger(IGlobalLogger logger, NoneLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly NoneLogSettings _settings;

        public void OnEntered()
        {
            if (_settings.IsAvailable(NoneLogType.Entered) == false)
                return;

            _logger.Log("None entered", _settings.LogParameters);
        }

        public void OnExited()
        {
            if (_settings.IsAvailable(NoneLogType.Entered) == false)
                return;

            _logger.Log("None exited", _settings.LogParameters);
        }
    }
}