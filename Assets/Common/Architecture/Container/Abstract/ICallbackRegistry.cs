namespace Common.Architecture.Container.Abstract
{
    public interface ICallbackRegistry
    {
        void Listen(object listener);
    }
}