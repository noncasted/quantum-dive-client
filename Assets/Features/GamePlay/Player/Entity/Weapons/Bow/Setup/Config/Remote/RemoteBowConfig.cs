using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Rotations.Remote;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Aims.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Reloads.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Remote;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowConfigRoutes.RemoteName,
        menuName = BowConfigRoutes.RemotePath)]
    public class RemoteBowConfig : ScriptableObject
    {
        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteAimFactory _aim;
        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteReloadFactory _reload;
        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteShootFactory _shoot;
        [FoldoutGroup("Combat")] [SerializeField] [Indent]
        private RemoteStrafeFactory _strafes;

        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private ProjectileStarterFactory _projectileStarter;
        [FoldoutGroup("Common")] [SerializeField] [Indent]
        private RemoteBowRotationFactory _rotation;

        public IComponentFactory[] GetFactories()
        {
            return new IComponentFactory[]
            {
                _aim,
                _reload,
                _shoot,
                _strafes,
                _projectileStarter,
                _rotation
            };
        }
    }
}