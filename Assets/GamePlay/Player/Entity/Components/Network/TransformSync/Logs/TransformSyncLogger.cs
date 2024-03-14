using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Abstract;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Network.TransformSync.Logs
{
    public class TransformSyncLogger
    {
        public TransformSyncLogger(
            IPlayerGameObject gameObject,
            IEntityProvider entityProvider,
            TransformSyncDebugFlag debugFlag,
            IGlobalLogger logger,
            TransformSyncLogSettings settings)
        {
            _gameObject = gameObject;
            _entityProvider = entityProvider;
            _debugFlag = debugFlag;
            _logger = logger;
            _settings = settings;
        }

        private readonly IPlayerGameObject _gameObject;
        private readonly IEntityProvider _entityProvider;
        private readonly TransformSyncDebugFlag _debugFlag;
        private readonly IGlobalLogger _logger;
        private readonly TransformSyncLogSettings _settings;

        public void OnSerialize(Vector2 position)
        {
            if (_settings.IsAvailable(TransformSyncLogType.Serialize) == false || _debugFlag.IsActive == false)
                return;

            _logger.Log($"Serialize {_gameObject.Name}:{_entityProvider.Id} transform position: {position}", _settings.LogParameters);
        }
        
        public void OnDeserialize(Vector2 position)
        {
            if (_settings.IsAvailable(TransformSyncLogType.Deserialize) == false || _debugFlag.IsActive == false)
                return;

            _logger.Log($"Deserialize {_gameObject.Name}:{_entityProvider.Id} transform position: {position}", _settings.LogParameters);
        }
    }
}