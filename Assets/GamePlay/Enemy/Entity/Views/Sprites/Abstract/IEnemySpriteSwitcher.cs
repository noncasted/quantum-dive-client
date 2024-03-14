namespace GamePlay.Enemy.Entity.Views.Sprites.Abstract
{
    public interface IEnemySpriteSwitcher
    {
        void Enable(bool enableSubSprites = false);
        void Disable(bool disableSubSprites = false);
    }
}