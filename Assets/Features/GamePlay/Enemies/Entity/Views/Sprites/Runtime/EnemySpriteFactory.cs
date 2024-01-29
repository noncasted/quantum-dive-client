using System;
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Entity.Views.Sprites.Logs;
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlay.Enemies.Entity.Views.Sprites.Runtime
{
    [Serializable]
    public class EnemySpriteFactory : IEnemyComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SortingGroup _sortingGroup;
        [SerializeField] private SpriteLogSettings _logSettings;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<SpriteLogger>()
                .WithParameter(_logSettings);

            services.Register<EnemySprite>()
                .AsImplementedInterfaces()
                .WithParameter(_spriteRenderer)
                .WithParameter(_sortingGroup);
        }
    }
}