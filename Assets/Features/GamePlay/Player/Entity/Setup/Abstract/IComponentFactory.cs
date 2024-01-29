using Common.Architecture.Container.Abstract;

namespace GamePlay.Player.Entity.Setup.Abstract
{
    public interface IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks);
    }
}