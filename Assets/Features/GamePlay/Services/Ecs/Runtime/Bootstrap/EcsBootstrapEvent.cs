namespace GamePlay.Ecs.Runtime.Bootstrap
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