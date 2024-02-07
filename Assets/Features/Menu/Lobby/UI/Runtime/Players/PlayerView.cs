using Menu.Services.Network.PlayersLists.Runtime;
using UnityEngine;

namespace Menu.Lobby.UI.Runtime.Players
{
    [DisallowMultipleComponent]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject _icon;
        
        public void Construct(PlayerData data)
        {
            //_name.text = data.Name;
            
            _icon.SetActive(data.IsMaster);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}