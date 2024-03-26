using Global.UI.Design.Abstract.Buttons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Design.Runtime.Buttons
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "DesignButtonColor", menuName = "UI/Design/Button/Config")]
    public class ButtonColorConfig : ScriptableObject, IButtonColorConfig
    {
        [SerializeField] [Min(0f)] private float _stateTransitionTime;
        
        [SerializeField] private Color _idle;
        [SerializeField] private Color _hovered;
        [SerializeField] private Color _pressed;

        public float StateTransitionTime => _stateTransitionTime;
        public Color Idle => _idle;
        public Color Hovered => _hovered;
        public Color Pressed => _pressed;
    }
}