namespace GamePlay.Services.System.Ecs.Abstract
{
    public interface IEntityComponentSetter
    {
        ref T Add<T>(int entity) where T : struct;
        void Remove<T>(int entity) where T : struct;
    }
}