using VContainer.Unity;

namespace GamePlay.Player.Entity.Setup.Scope
{
    public interface IParentScopeProvider
    {
        LifetimeScope Scope { get; }
    }
}