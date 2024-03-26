using Common.DataTypes.Runtime.Reactive;
using Nova;
using NovaSamples.UIControls;
using TMPro;
using Tools.AssembliesViewer.Domain.Abstract;
using UnityEngine;

namespace Tools.AssembliesViewer.Graph.Tree
{
    [DisallowMultipleComponent]
    public class GraphTreeAssembly : MonoBehaviour, IGraphTreeEntry
    {
        [SerializeField] private float _baseSize;
        [SerializeField] private UIBlock2D _block;
        [SerializeField] private TMP_Text _assemblyName;
        [SerializeField] private Toggle _toggle;
        
        private bool _isExpanded;

        private readonly ViewableProperty<bool> _isToggled = new();

        private IAssembly _assembly;

        private readonly ViewableProperty<float> _size = new();

        public UIBlock2D Block => _block;
        public IViewableProperty<float> Size => _size;
        public IViewableProperty<bool> IsToggled => _isToggled;

        private void Awake()
        {
            _size.Set(_block.Size.Value.y);
        }
        
        private void OnEnable()
        {
            _toggle.OnToggled.AddListener(OnToggleClicked);
        }

        private void OnDisable()
        {
            _toggle.OnToggled.RemoveListener(OnToggleClicked);
        }

        public void Construct(IAssembly assembly, bool isToggled)
        {
            _assembly = assembly;
            name = assembly.DirectoryName;
            _assemblyName.text = assembly.DirectoryName;
            _toggle.ToggledOn = isToggled;
            
            _size.Set(_baseSize);
            
            _isToggled.Set(isToggled);
        }

        private void OnToggleClicked(bool value)
        {
            _isToggled.Set(value);
        }
    }
}