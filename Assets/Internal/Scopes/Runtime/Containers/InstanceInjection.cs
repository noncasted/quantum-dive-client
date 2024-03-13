using VContainer;

namespace Internal.Scopes.Runtime.Containers
{
    public class InstanceInjection
    {
        public InstanceInjection(object target)
        {
            _target = target;
        }

        private readonly object _target;

        public void Inject(IObjectResolver resolver)
        {
            resolver.Inject(_target);
        }
    }
}