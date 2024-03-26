using Internal.Scopes.Abstract.Lifetimes;
using UnityEngine;

namespace Global.UI.Design.Abstract.Buttons
{
    public abstract class DesignButtonBehaviour : MonoBehaviour
    {
        public abstract void Construct(IDesignButton button, IReadOnlyLifetime lifetime);
    }
}