using Common.Architecture.Lifetimes.Viewables;

namespace Global.Inputs.View.Implementations.Movement
{
    public interface IRollInputView
    {
        IViewableDelegate Performed { get; }
        IViewableDelegate Canceled { get; }
    }
}