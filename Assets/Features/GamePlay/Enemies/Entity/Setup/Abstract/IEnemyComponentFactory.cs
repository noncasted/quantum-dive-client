using Common.Architecture.Container.Abstract;

namespace GamePlay.Enemies.Entity.Setup.Abstract
{
    public interface IEnemyComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegistry callbacks);
    }
}