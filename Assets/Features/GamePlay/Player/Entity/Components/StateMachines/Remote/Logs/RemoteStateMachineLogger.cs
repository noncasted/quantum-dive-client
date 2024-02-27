using GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using Internal.Services.Loggers.Runtime;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Logs
{
    public class RemoteStateMachineLogger
    {
        public RemoteStateMachineLogger(
            IEntityProvider entityProvider,
            IPlayerGameObject gameObject,
            IGlobalLogger logger,
            RemoteStateMachineDebugFlag debugFlag,
            RemoteStateMachineLogSettings settings)
        {
            _entityProvider = entityProvider;
            _gameObject = gameObject;
            _debugFlag = debugFlag;
            _logger = logger;
            _settings = settings;
        }

        private readonly IEntityProvider _entityProvider;
        private readonly IPlayerGameObject _gameObject;
        private readonly IGlobalLogger _logger;
        private readonly RemoteStateMachineDebugFlag _debugFlag;
        private readonly RemoteStateMachineLogSettings _settings;

        public void OnStateRegistered(int stateId, string stateName)
        {
            if (_settings.IsAvailable(RemoteStateMachineLogType.StateRegistration) == false || _debugFlag.IsActive == false)
                return;

            stateName = ProcessName(stateName);

            _logger.Log($"{_gameObject.Name}:{_entityProvider.Id} registered state: {stateName}:{stateId}", _settings.LogParameters);
        }
        
        public void OnStateUnregistered(int stateId, string stateName)
        {
            if (_settings.IsAvailable(RemoteStateMachineLogType.StateUnregistration) == false || _debugFlag.IsActive == false)
                return;

            stateName = ProcessName(stateName);

            _logger.Log($"{_gameObject.Name}:{_entityProvider.Id} unregistered state: {stateName}:{stateId}", _settings.LogParameters);
        }
        
        public void OnSerialize(int stateId, string stateName)
        {
            if (_settings.IsAvailable(RemoteStateMachineLogType.Serialize) == false || _debugFlag.IsActive == false)
                return;

            stateName = ProcessName(stateName);

            _logger.Log($"Serialize {_gameObject.Name}:{_entityProvider.Id} animation: {stateName}:{stateId}", _settings.LogParameters);
        }
        
        public void OnDeserialize(int stateId, string stateName)
        {
            if (_settings.IsAvailable(RemoteStateMachineLogType.Deserialize) == false || _debugFlag.IsActive == false)
                return;

            stateName = ProcessName(stateName);
            
            _logger.Log($"Deserialize {_gameObject.Name}:{_entityProvider.Id} animation: {stateName}:{stateId}", _settings.LogParameters);
        }
        
        public void OnDeserialize(int stateId)
        {
            if (_settings.IsAvailable(RemoteStateMachineLogType.Deserialize) == false || _debugFlag.IsActive == false)
                return;

            _logger.Log($"Deserialize {_gameObject.Name}:{_entityProvider.Id} animation: {stateId}", _settings.LogParameters);
        }

        private string ProcessName(string name)
        {
            name = name.Replace("PlayerStateDefinition_", "");
            name = name.Replace("PlayerState_", "");

            return name;
        }
    }
}