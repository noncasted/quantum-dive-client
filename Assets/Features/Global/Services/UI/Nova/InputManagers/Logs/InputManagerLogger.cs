using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace Global.UI.Nova.InputManagers.Logs
{
    public class InputManagerLogger
    {
        public InputManagerLogger(IGlobalLogger logger, InputManagerLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly InputManagerLogSettings _settings;

        public void OnMouseScroll(Vector2 scroll)
        {
            if (_settings.IsAvailable(InputManagerLogType.Mouse_Scroll) == false)
                return;
        
            _logger.Log($"Mouse scroll: {scroll}", _settings.LogParameters);
        }
        
        public void OnMousePosition(Vector2 mousePosition)
        {
            if (_settings.IsAvailable(InputManagerLogType.Mouse_Position) == false)
                return;
        
            _logger.Log($"Mouse position: {mousePosition}", _settings.LogParameters);
        }
        
        
        public void OnLeftMouseButton(bool isPressed, bool isUp)
        {
            if (_settings.IsAvailable(InputManagerLogType.Mouse_LeftDown) == false)
                return;
        
            _logger.Log($"Left mouse button: isPressed: {isPressed}, isUp: {isUp}", _settings.LogParameters);
        }
    }
}