using VContainer.Unity;

namespace GamePlay.Player.Entity.Setup.Scope
{
    public class ParentScopeProvider : IParentScopeProvider
    {
        public ParentScopeProvider(PlayerScope scope)
        {
            _scope = scope;
        }
        
        private readonly PlayerScope _scope;

        public LifetimeScope Scope => _scope;
    }
}