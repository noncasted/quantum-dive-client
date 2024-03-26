using Nova;
using UnityEngine;

namespace Global.UI.Design.Runtime.DataBindings
{
    public class ListViewVisuals<T> : ItemVisuals
    {
        [SerializeField] private T _entry;

        public T Entry => _entry;
        
    }
}