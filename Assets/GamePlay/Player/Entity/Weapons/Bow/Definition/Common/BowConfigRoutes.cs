﻿using GamePlay.Player.Entity.Weapons.Bow.Components.Common.Paths;

namespace GamePlay.Player.Entity.Weapons.Bow.Definition.Common
{
    public class BowConfigRoutes
    {
        public const string LocalName = BowAssetsPrefixes.Config + "Local";
        public const string LocalPath = BowAssetsPaths.Root + "Config/Local";
        
        public const string RemoteName = BowAssetsPrefixes.Config + "Remote";
        public const string RemotePath = BowAssetsPaths.Root + "Config/Remote";
        
        public const string ComposeName = "BowConfigCompose";
        public const string ComposePath = BowAssetsPaths.Root + "Config/Compose";
    }
}