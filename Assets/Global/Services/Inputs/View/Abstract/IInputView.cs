using System;
using Common.DataTypes.Reactive;
using Internal.Scopes.Abstract.Lifetimes;

namespace Global.Inputs.View.Abstract
{
    public interface IInputView
    {
        IViewableProperty<ILifetime> ListenLifetime { get; }
    }
}