namespace Global.Inputs.View.Abstract
{
    public interface IInputSource
    {
        void Listen();
        void Dispose();
    }
}