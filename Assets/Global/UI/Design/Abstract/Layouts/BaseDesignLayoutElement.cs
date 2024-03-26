using Common.DataTypes.Runtime.Reactive;
using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace Global.UI.Design.Abstract.AutoLayouts
{
    public abstract class BaseDesignLayoutElement : MonoBehaviour
    {
        public abstract IViewableProperty<float> Height { get; }

        public abstract void BindChild(BaseDesignLayoutElement child);
        public abstract void ForceRecalculate();
    }
}