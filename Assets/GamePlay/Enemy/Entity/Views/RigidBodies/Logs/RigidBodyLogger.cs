using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.RigidBodies.Logs
{
    public class RigidBodyLogger
    {
        public RigidBodyLogger(IGlobalLogger logger, RigidBodyLogSettings settings, RigidBodyDebugFlag flag)
        {
            _logger = logger;
            _settings = settings;
            _flag = flag;
        }

        private readonly IGlobalLogger _logger;
        private readonly RigidBodyLogSettings _settings;
        private readonly RigidBodyDebugFlag _flag;

        public void OnPositionSet(Vector2 position)
        {
            if (_settings.IsAvailable(RigidBodyLogType.PositionSet) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Position setted: {position}", _settings.LogParameters);
        }

        public void OnMoveEnqueued(Vector2 direction, float distance)
        {
            if (_settings.IsAvailable(RigidBodyLogType.MoveEnqueue) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Move enqueued: direction: {direction}, distance: {distance}", _settings.LogParameters);
        }

        public void OnMoveProcessed(Vector2 direction, float distance, Vector2 result)
        {
            if (_settings.IsAvailable(RigidBodyLogType.MoveProcess) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Move processed: direction: {direction}, distance: {distance}, result: {result}",
                _settings.LogParameters);
        }

        public void OnPositionUse(Vector2 position)
        {
            if (_settings.IsAvailable(RigidBodyLogType.PositionUse) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Position used: {position}", _settings.LogParameters);
        }
    }
}