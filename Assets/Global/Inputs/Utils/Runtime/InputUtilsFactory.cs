﻿using Cysharp.Threading.Tasks;
using Global.Inputs.Utils.Abstract;
using Global.Inputs.Utils.Common;
using Global.Inputs.Utils.Runtime.Conversion;
using Global.Inputs.Utils.Runtime.Projection;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.Utils.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputUtilsRoutes.ServiceName, menuName = InputUtilsRoutes.ServicePath)]
    public class InputUtilsFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<InputConversion>()
                .As<IInputConversion>();

            services.Register<InputProjection>()
                .As<IInputProjection>();
        }
    }
}