using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Physics.Logs
{
    public class PhysicsLogger
    {
        public PhysicsLogger(IGlobalLogger logger, PhysicsLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly PhysicsLogSettings _settings;

        public void OnPositionSet(Vector2 position)
        {
            if (_settings.IsAvailable(RigidBodyLogType.PositionSet) == false)
                return;

            _logger.Log($"Position setted: {position}", _settings.LogParameters);
        }

        public void OnMoveEnqueued(Vector2 direction, float distance)
        {
            if (_settings.IsAvailable(RigidBodyLogType.MoveEnqueue) == false)
                return;

            _logger.Log($"Move enqueued: direction: {direction}, distance: {distance}", _settings.LogParameters);
        }

        public void OnMoveProcessed(Vector2 direction, float distance, Vector2 result)
        {
            if (_settings.IsAvailable(RigidBodyLogType.MoveProcess) == false)
                return;

            _logger.Log($"Move processed: direction: {direction}, distance: {distance}, result: {result}",
                _settings.LogParameters);
        }

        public void OnPositionUse(Vector2 position)
        {
            if (_settings.IsAvailable(RigidBodyLogType.PositionUse) == false)
                return;

            _logger.Log($"Position used: {position}", _settings.LogParameters);
        }
    }
}