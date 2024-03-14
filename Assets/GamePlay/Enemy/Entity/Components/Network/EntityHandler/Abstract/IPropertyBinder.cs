using Ragon.Client;

namespace GamePlay.Enemy.Entity.Components.Network.EntityHandler.Abstract
{
    public interface IPropertyBinder
    {
        void BindProperty(RagonProperty property);
    }
}