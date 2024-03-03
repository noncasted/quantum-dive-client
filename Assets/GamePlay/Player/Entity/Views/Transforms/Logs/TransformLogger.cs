﻿using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Logs
{
    public class TransformLogger
    {
        public TransformLogger(IGlobalLogger logger, TransformLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly TransformLogSettings _settings;

        public void OnPositionUsed(Vector2 position)
        {
            if (_settings.IsAvailable(TransformLogType.PositionUse) == false)
                return;

            _logger.Log($"Used: {position}", _settings.LogParameters);
        }

        public void OnPositionSet(Vector2 position)
        {
            if (_settings.IsAvailable(TransformLogType.PositionSet) == false)
                return;

            _logger.Log($"Set position: {position}", _settings.LogParameters);
        }

        public void OnRotationSet(float angle)
        {
            if (_settings.IsAvailable(TransformLogType.PositionSet) == false)
                return;

            _logger.Log($"Set angle: {angle}", _settings.LogParameters);
        }
    }
}