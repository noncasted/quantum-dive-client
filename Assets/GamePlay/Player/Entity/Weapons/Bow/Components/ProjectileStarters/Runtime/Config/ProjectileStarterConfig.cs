namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config
{
    public class ProjectileStarterConfig : IProjectileStarterConfig
    {
        public ProjectileStarterConfig(ProjectileStarterConfigAsset asset)
        {
            _asset = asset;
        }

        private readonly ProjectileStarterConfigAsset _asset;

        public ProjectileData Data => _asset.Data;
        public float Scale => _asset.Scale;
        public float Radius => _asset.Radius;
    }
}