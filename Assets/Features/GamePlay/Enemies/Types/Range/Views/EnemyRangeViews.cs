using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Range.Views.ShootPoint;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.Views
{
    public class EnemyRangeViews : MonoBehaviour, IEnemyContainerBuilder
    {
        [SerializeField] private ShootPointFactory _shootPoint;
        
        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
        {
            _shootPoint.Create(services, callbacks);
        }
    }
}