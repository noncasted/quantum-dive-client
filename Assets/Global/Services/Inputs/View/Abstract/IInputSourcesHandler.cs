namespace Global.Inputs.View.Abstract
{
    public interface IInputSourcesHandler
    {
        void AddListener(IInputSource source);
        
        void InvokeListen();
        void Dispose();
    }
}