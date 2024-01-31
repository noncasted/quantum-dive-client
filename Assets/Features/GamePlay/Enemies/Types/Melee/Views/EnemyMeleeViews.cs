using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Melee.States.Attack.Damages;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.Views
{
    [DisallowMultipleComponent]
    public class EnemyMeleeViews : MonoBehaviour, IEnemyContainerBuilder
    {
        [SerializeField] private MeleeDamageDealerFactory _damageDealer;

        public void OnBuild(IServiceCollection services, ICallbackRegistry callbacks)
        {
            _damageDealer.Create(services, callbacks);
        }
    }
}