using GamePlay.Player.Entity.States.Common;
using Internal.Loggers.Runtime;

namespace GamePlay.Player.Entity.Components.StateMachines.Local.Logs
{
    public class LocalStateMachineLogger
    {
        public LocalStateMachineLogger(IGlobalLogger logger, LocalStateMachineLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly LocalStateMachineLogSettings _settings;

        public void OnAvailabilityChecked(PlayerStateDefinition from, PlayerStateDefinition to, bool result)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.AvailablityCheck) == false)
                return;

            _logger.Log($"Availability {from.name} -> {to.name} : {result}", _settings.LogParameters);
        }

        public void OnEnteredFirst(PlayerStateDefinition next)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.Entered) == false)
                return;

            _logger.Log($"Entered {next.name}", _settings.LogParameters);
        }

        public void OnEnteredFrom(PlayerStateDefinition previous, PlayerStateDefinition next)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.Entered) == false)
                return;

            _logger.Log($"Entered {next.name}, previous: {previous.name}", _settings.LogParameters);
        }

        public void OnExited(PlayerStateDefinition previous)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.Exited) == false)
                return;

            _logger.Log($"Exited {previous.name}", _settings.LogParameters);
        }
        
        public void OnExitMiss(PlayerStateDefinition previous)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.ExitMiss) == false)
                return;

            _logger.Log($"Exit miss from {previous.name}", _settings.LogParameters);
        }
    }
}