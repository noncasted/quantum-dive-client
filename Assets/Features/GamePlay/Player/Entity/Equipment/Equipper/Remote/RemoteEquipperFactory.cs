using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Equipper.Common;

using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Equipper.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.RemoteName,
        menuName = EquipperRoutes.RemotePath)]
    public class RemoteEquipperFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteEquipper>()
                .As<IEquipperSync>()
                .AsSelf();
        }
    }
}