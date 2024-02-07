﻿using UnityEngine;
using ILogger = Internal.Services.Loggers.Runtime.ILogger;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Logs
{
    public class TransformLogger
    {
        public TransformLogger(ILogger logger, TransformLogSettings settings, LocalTransformDebugFlag flag)
        {
            _logger = logger;
            _settings = settings;
            _flag = flag;
        }

        private readonly ILogger _logger;
        private readonly TransformLogSettings _settings;
        private readonly LocalTransformDebugFlag _flag;

        public void OnPositionUsed(Vector2 position)
        {
            if (_settings.IsAvailable(TransformLogType.PositionUse) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Used: {position}", _settings.LogParameters);
        }

        public void OnPositionSet(Vector2 position)
        {
            if (_settings.IsAvailable(TransformLogType.PositionSet) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Set position: {position}", _settings.LogParameters);
        }

        public void OnRotationSet(float angle)
        {
            if (_settings.IsAvailable(TransformLogType.PositionSet) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Set angle: {angle}", _settings.LogParameters);
        }
    }
}