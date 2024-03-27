using GamePlay.Services.System.Ecs.Abstract;

namespace GamePlay.Services.Ecs.Runtime.Bootstrap
{
    public readonly struct EcsBootstrapEvent
    {
        public EcsBootstrapEvent(IEcsSystemBinder binder)
        {
            Binder = binder;
        }

        public readonly IEcsSystemBinder Binder;
    }
}