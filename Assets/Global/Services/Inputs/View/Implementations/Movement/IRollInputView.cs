using Common.DataTypes.Reactive;

namespace Global.Inputs.View.Implementations.Movement
{
    public interface IRollInputView
    {
        IViewableDelegate Performed { get; }
        IViewableDelegate Canceled { get; }
    }
}