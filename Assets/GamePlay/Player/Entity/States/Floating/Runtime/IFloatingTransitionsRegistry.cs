using Common.Architecture.Lifetimes;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Floating.Runtime
{
    public interface IFloatingTransitionsRegistry
    {
        void Register(ILifetime lifetime, PlayerStateDefinition definition, IFloatingTransition transition);
    }
}