using Ragon.Client;

namespace GamePlay.Enemy.Entity.Network.EntityHandler.Runtime
{
    public interface IPropertyBinder
    {
        void BindProperty(RagonProperty property);
    }
}