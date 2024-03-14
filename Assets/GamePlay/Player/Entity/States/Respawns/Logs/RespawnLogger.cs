using Internal.Services.Loggers.Runtime;

namespace GamePlay.Player.Entity.States.Respawns.Logs
{
    public class RespawnLogger
    {
        public RespawnLogger(IGlobalLogger logger, RespawnLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly RespawnLogSettings _settings;

        public void OnEntered()
        {
            if (_settings.IsAvailable(RespawnLogType.Entered) == false)
                return;

            _logger.Log("Respawn entered", _settings.LogParameters);
        }

        public void OnBroke()
        {
            if (_settings.IsAvailable(RespawnLogType.Broke) == false)
                return;

            _logger.Log("Respawn broke", _settings.LogParameters);
        }
    }
}