using Common.DataTypes.Runtime.Reactive;

namespace Global.UI.Design.Abstract.Buttons
{
    public interface IDesignButton
    {
        IViewableDelegate Clicked { get; }
        IViewableProperty<DesignButtonState> State { get; }

        void Lock();
        void Unlock();
    }
}