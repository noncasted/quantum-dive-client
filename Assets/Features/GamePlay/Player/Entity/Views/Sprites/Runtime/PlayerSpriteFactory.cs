using System;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Views.Sprites.Logs;
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlay.Player.Entity.Views.Sprites.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerSpriteFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SortingGroup _sortingGroup;
        [SerializeField] private SpriteLogSettings _logSettings;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SpriteLogger>()
                .WithParameter(_logSettings);

            services.Register<PlayerPlayerSprite>()
                .AsImplementedInterfaces()
                .WithParameter(_spriteRenderer)
                .WithParameter(_sortingGroup);
        }
    }
}