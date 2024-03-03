using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Logs
{
    public class SpriteLogger
    {
        public SpriteLogger(IGlobalLogger logger, SpriteLogSettings settings, SpriteDebugFlag flag)
        {
            _logger = logger;
            _settings = settings;
            _flag = flag;
        }

        private readonly IGlobalLogger _logger;
        private readonly SpriteLogSettings _settings;
        private readonly SpriteDebugFlag _flag;

        public void OnEnabled()
        {
            if (_settings.IsAvailable(SpriteLogType.Enable) == false || _flag.IsActive == false)
                return;

            _logger.Log("Enabled", _settings.LogParameters);
        }

        public void OnDisabled()
        {
            if (_settings.IsAvailable(SpriteLogType.Disable) == false || _flag.IsActive == false)
                return;

            _logger.Log("Disabled", _settings.LogParameters);
        }

        public void OnMaterialUsed(Material material)
        {
            if (_settings.IsAvailable(SpriteLogType.MaterialUse) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Material {material.name} used", _settings.LogParameters);
        }

        public void OnMaterialSetted(Material material)
        {
            if (_settings.IsAvailable(SpriteLogType.MaterialSet) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Material {material.name} setted", _settings.LogParameters);
        }

        public void OnFlipSetted(bool isFlipped)
        {
            if (_settings.IsAvailable(SpriteLogType.FlipSet) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Flip {isFlipped} setted", _settings.LogParameters);
        }

        public void OnFlippedAlong(Vector2 direction)
        {
            if (_settings.IsAvailable(SpriteLogType.FlipSet) == false || _flag.IsActive == false)
                return;

            _logger.Log($"Flipped along {direction}", _settings.LogParameters);
        }
    }
}