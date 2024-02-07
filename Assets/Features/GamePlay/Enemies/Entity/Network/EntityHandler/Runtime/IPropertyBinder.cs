using Ragon.Client;

namespace GamePlay.Enemies.Entity.Network.EntityHandler
{
    public interface IPropertyBinder
    {
        void BindProperty(RagonProperty property);
    }
}