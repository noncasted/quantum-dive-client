using Common.Architecture.Container.Abstract;

namespace GamePlay.Enemies.Entity.Setup.Abstract
{
    public interface IEnemyContainerBuilder
    {
        void OnBuild(IServiceCollection services, ICallbackRegister callbacks);
    }
}