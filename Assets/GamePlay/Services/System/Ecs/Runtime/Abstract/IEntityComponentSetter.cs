namespace GamePlay.System.Ecs.Runtime.Abstract
{
    public interface IEntityComponentSetter
    {
        ref T Add<T>(int entity) where T : struct;
        void Remove<T>(int entity) where T : struct;
    }
}