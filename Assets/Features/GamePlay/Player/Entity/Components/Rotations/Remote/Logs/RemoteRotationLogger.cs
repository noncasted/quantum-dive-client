using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using Internal.Services.Loggers.Runtime;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Logs
{
    public class RemoteRotationLogger
    {
        public RemoteRotationLogger(
            IPlayerGameObject gameObject,
            IEntityProvider entityProvider,
            RotationSyncDebugFlag debugFlag,
            ILogger logger,
            RemoteRotationLogSettings settings)
        {
            _gameObject = gameObject;
            _entityProvider = entityProvider;
            _debugFlag = debugFlag;
            _logger = logger;
            _settings = settings;
        }

        private readonly IPlayerGameObject _gameObject;
        private readonly IEntityProvider _entityProvider;
        private readonly RotationSyncDebugFlag _debugFlag;
        private readonly ILogger _logger;
        private readonly RemoteRotationLogSettings _settings;

        public void OnSerialize(float value)
        {
            if (_settings.IsAvailable(RemoteRotationLogType.Serialize) == false || _debugFlag.IsActive == false)
                return;

            _logger.Log($"Serialize {_gameObject.Name}:{_entityProvider.Id} rotation: {value}", _settings.LogParameters);
        }
        
        public void OnDeserialize(float value)
        {
            if (_settings.IsAvailable(RemoteRotationLogType.Deserialize) == false || _debugFlag.IsActive == false)
                return;

            _logger.Log($"Deserialize {_gameObject.Name}:{_entityProvider.Id} rotation: {value}", _settings.LogParameters);
        }
    }
}