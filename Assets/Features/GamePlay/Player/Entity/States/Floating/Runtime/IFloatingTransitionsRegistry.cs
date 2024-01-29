using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.States.Floating.Runtime
{
    public interface IFloatingTransitionsRegistry
    {
        void Register(PlayerStateDefinition definition, IFloatingTransition transition);
        void Unregister(PlayerStateDefinition definition);
    }
}