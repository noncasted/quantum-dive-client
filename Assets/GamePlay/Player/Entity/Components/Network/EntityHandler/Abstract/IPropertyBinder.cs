using Ragon.Client;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract
{
    public interface IPropertyBinder
    {
        void BindProperty(RagonProperty property);
    }
}