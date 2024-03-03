using Internal.Loggers.Runtime;

namespace Global.System.ScopeDisposer.Logs
{
    public class ScopeDisposerLogger
    {
        public ScopeDisposerLogger(IGlobalLogger logger, ScopeDisposerLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly ScopeDisposerLogSettings _settings;


        public void OnUnload(int scenesCount)
        {
            if (_settings.IsAvailable(ScopeDisposerLogType.Unload) == false)
                return;

            _logger.Log($"Unloading {scenesCount} scenes", _settings.LogParameters);
        }

        public void OnUnloadingFinalized()
        {
            if (_settings.IsAvailable(ScopeDisposerLogType.FinalizeUnloading) == false)
                return;

            _logger.Log("Scenes unloading finalized", _settings.LogParameters);
        }
    }
}