using GamePlay.Enemies.Entity.States.Abstract;
using Internal.Services.Loggers.Runtime;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Local.Logs
{
    public class LocalStateMachineLogger
    {
        public LocalStateMachineLogger(ILogger logger, LocalStateMachineLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly LocalStateMachineLogSettings _settings;

        public void OnAvailabilityChecked(EnemyStateDefinition from, EnemyStateDefinition to, bool result)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.AvailablityCheck) == false)
                return;

            _logger.Log($"Availability {from.name} -> {to.name} : {result}", _settings.LogParameters);
        }

        public void OnEnteredFirst(EnemyStateDefinition next)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.Entered) == false)
                return;

            _logger.Log($"Entered {next.name}", _settings.LogParameters);
        }

        public void OnEnteredFrom(EnemyStateDefinition previous, EnemyStateDefinition next)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.Entered) == false)
                return;

            _logger.Log($"Entered {next.name}, previous: {previous.name}", _settings.LogParameters);
        }

        public void OnExited(EnemyStateDefinition previous)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.Exited) == false)
                return;

            _logger.Log($"Exited {previous.name}", _settings.LogParameters);
        }
        
        public void OnExitMiss(EnemyStateDefinition previous)
        {
            if (_settings.IsAvailable(LocalStateMachineLogType.ExitMiss) == false)
                return;

            _logger.Log($"Exit miss from {previous.name}", _settings.LogParameters);
        }
    }
}