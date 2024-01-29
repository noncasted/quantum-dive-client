using UnityEngine;
using ILogger = Internal.Services.Loggers.Runtime.ILogger;

namespace GamePlay.Player.Entity.Views.Sprites.Logs
{
    public class SpriteLogger
    {
        public SpriteLogger(ILogger logger, SpriteLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly SpriteLogSettings _settings;

        public void OnEnabled()
        {
            if (_settings.IsAvailable(SpriteLogType.Enable) == false)
                return;

            _logger.Log("Enabled", _settings.LogParameters);
        }

        public void OnDisabled()
        {
            if (_settings.IsAvailable(SpriteLogType.Disable) == false)
                return;

            _logger.Log("Disabled", _settings.LogParameters);
        }

        public void OnMaterialUsed(Material material)
        {
            if (_settings.IsAvailable(SpriteLogType.MaterialUse) == false)
                return;

            _logger.Log($"Material {material.name} used", _settings.LogParameters);
        }

        public void OnMaterialSetted(Material material)
        {
            if (_settings.IsAvailable(SpriteLogType.MaterialSet) == false)
                return;

            _logger.Log($"Material {material.name} setted", _settings.LogParameters);
        }

        public void OnFlipSetted(bool isFlipped)
        {
            if (_settings.IsAvailable(SpriteLogType.FlipSet) == false)
                return;

            _logger.Log($"Flip {isFlipped} setted", _settings.LogParameters);
        }

        public void OnFlippedAlong(Vector2 direction)
        {
            if (_settings.IsAvailable(SpriteLogType.FlipSet) == false)
                return;

            _logger.Log($"Flipped along {direction}", _settings.LogParameters);
        }
    }
}