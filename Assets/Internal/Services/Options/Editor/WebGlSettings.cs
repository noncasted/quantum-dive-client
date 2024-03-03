using UnityEditor;

namespace Internal.Options.Editor
{
    public class WebGlSettings
    {
        public WebGlSettings()
        {
            PlayerSettings.WebGL.emscriptenArgs = "-Wl,--trace-symbol=sendfile";
        }
    }
}