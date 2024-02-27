using Internal.Services.Loggers.Runtime;

namespace GamePlay.Player.Entity.States.Floating.Logs
{
    public class FloatingStateLogger
    {
        public FloatingStateLogger(IGlobalLogger logger, FloatingStateLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly FloatingStateLogSettings _settings;

        public void OnEntered()
        {
            if (_settings.IsAvailable(FloatingStateLogType.Entered) == false)
                return;

            _logger.Log("Entered: Floating", _settings.LogParameters);
        }
    }
}