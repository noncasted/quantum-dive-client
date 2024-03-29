﻿using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Input.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordInputRoutes.ComponentName, menuName = SwordInputRoutes.ComponentPath)]
    public class InputReceiverFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<InputReceiver>()
                .As<IInputReceiver>()
                .AsCallbackListener();
        }
    }
}