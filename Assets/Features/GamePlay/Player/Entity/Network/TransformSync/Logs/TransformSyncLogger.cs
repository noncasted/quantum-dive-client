﻿using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Views.GameObjects.Runtime;
using UnityEngine;
using ILogger = Internal.Services.Loggers.Runtime.ILogger;

namespace GamePlay.Player.Entity.Network.TransformSync.Logs
{
    public class TransformSyncLogger
    {
        public TransformSyncLogger(
            IPlayerGameObject gameObject,
            IEntityProvider entityProvider,
            TransformSyncDebugFlag debugFlag,
            ILogger logger,
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
        private readonly ILogger _logger;
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