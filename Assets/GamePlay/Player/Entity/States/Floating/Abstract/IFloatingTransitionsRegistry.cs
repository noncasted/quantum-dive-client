using GamePlay.Player.Entity.States.Common;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.States.Floating.Abstract
{
    public interface IFloatingTransitionsRegistry
    {
        void Register(ILifetime lifetime, PlayerStateDefinition definition, IFloatingTransition transition);
    }
}