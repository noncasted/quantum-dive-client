﻿using GamePlay.Player.Entity.States.None.Abstract;
using GamePlay.Player.Entity.States.None.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.None.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NoneRoutes.StateName,
        menuName = NoneRoutes.StatePath)]
    public class NoneFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private NoneDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
           services.Register<None>()
                .WithParameter(_definition)
                .As<INone>();
        }
    }
}