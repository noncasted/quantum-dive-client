using GamePlay.Player.UI.Overlay.Abstract;
using UnityEngine;

namespace GamePlay.Player.UI.Overlay.Runtime.State
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Canvas))]
    public class PlayerOverlayView : MonoBehaviour, IPlayerOverlayView
    {
        public GameObject Body => gameObject;
    }
}