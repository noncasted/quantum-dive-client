namespace GamePlay.Enemy.Entity.Views.Sprites.Runtime
{
    public interface IEnemySpriteSwitcher
    {
        void Enable(bool enableSubSprites = false);
        void Disable(bool disableSubSprites = false);
    }
}