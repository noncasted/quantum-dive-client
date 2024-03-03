using GamePlay.Enemy.Entity.Common.Routes;

namespace GamePlay.Enemy.Entity.Views.Sprites.Common
{
    public class SpriteViewRoutes
    {
        private const string _name = "Sprite";

        public const string LogsName = EnemyEntityPrefixes.Logs + _name;
        public const string LogsPath = EnemyEntityRoutes.Views + "Sprite/Local/" + "Logs";
    }
}