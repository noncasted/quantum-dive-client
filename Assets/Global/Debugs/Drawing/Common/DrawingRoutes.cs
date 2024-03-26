using Global.Common;
using Global.Common.Paths;

namespace Global.Debugs.Drawing.Common
{
    public static class DrawingRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Debug/Drawing/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "Drawing";
    }
}