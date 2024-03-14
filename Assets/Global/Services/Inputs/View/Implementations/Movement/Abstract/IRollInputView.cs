using Common.DataTypes.Reactive;

namespace Global.Inputs.View.Implementations.Movement.Abstract
{
    public interface IRollInputView
    {
        IViewableDelegate Performed { get; }
        IViewableDelegate Canceled { get; }
    }
}