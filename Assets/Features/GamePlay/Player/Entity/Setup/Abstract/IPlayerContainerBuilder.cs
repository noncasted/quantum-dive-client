using Common.Architecture.Container.Abstract;

namespace GamePlay.Player.Entity.Setup.Abstract
{
    public interface IPlayerContainerBuilder
    {
        void OnBuild(IServiceCollection services, ICallbackRegister callbacks);
    }
}