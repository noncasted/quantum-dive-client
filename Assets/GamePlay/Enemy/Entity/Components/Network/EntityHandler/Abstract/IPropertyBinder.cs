using Ragon.Client;

namespace GamePlay.Enemy.Entity.Components.Network.EntityHandler.Runtime
{
    public interface IPropertyBinder
    {
        void BindProperty(RagonProperty property);
    }
}