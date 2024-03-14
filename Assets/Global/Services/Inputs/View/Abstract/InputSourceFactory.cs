using Internal.Scopes.Abstract.Containers;
using UnityEngine;

namespace Global.Inputs.View.Abstract
{
    public abstract class InputSourceFactory : ScriptableObject
    {
        public abstract void Create(Controls controls, IServiceCollection services);
    }
}