using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Equipment.Equipper.Common;
using GamePlay.Player.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Equipper.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.RemoteName,
        menuName = EquipperRoutes.RemotePath)]
    public class RemoteEquipperFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<RemoteEquipper>()
                .As<IEquipperSync>()
                .AsSelf();
        }
    }
}