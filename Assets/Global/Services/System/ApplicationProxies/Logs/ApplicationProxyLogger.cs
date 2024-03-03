using Internal.Loggers.Runtime;

namespace Global.System.ApplicationProxies.Logs
{
    public class ApplicationProxyLogger
    {
        public ApplicationProxyLogger(IGlobalLogger logger, ApplicationProxyLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly ApplicationProxyLogSettings _settings;

        public void OnQuit()
        {
            if (_settings.IsAvailable(ApplicationProxyLogType.Quit) == false)
                return;

            _logger.Log("Quit", _settings.LogParameters);
        }
    }
}