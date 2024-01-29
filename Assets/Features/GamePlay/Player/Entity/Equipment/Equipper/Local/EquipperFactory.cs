using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Equipment.Equipper.Common;
using GamePlay.Player.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Equipment.Equipper.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EquipperRoutes.LocalName,
        menuName = EquipperRoutes.LocalPath)]
    public class EquipperFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<Equipper>()
                .As<IEquipper>();
        }
    }
}