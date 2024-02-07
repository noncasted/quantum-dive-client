using GamePlay.Common.Routes;

namespace GamePlay.VfxPools.Common
{
    public static class VfxPoolRoutes
    {
        public const string ServiceName = GamePlayServicesPrefixes.Service + "VfxPool";
        public const string ServicePath = GamePlayServicesRoutes.Root + "VfxPool/Service";

        public const string AnimatedName = "AnimatedVfx_";
        public const string AnimatedPath = GamePlayServicesRoutes.Root + "VfxPool/Animated";

        public const string ParticleName = "ParticleVfx_";
        public const string ParticlePath = GamePlayServicesRoutes.Root + "VfxPool/Particle";
    }
}