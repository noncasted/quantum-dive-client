using Ragon.Client;

namespace GamePlay.Enemies.Entity.Network.EntityHandler.Runtime
{
    public interface IPropertyBinder
    {
        void BindProperty(RagonProperty property);
    }
}