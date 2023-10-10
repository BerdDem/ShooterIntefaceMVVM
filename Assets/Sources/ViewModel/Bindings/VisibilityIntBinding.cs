using Sources.ViewModel.Properties.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Sources.ViewModel.Bindings
{
    public class VisibilityIntBinding : Binding<IIntProperty>
    {
        [SerializeField] private int _key;
        [SerializeField] private bool _invert;

        protected override void OnUpdateValue()
        {
            base.OnUpdateValue();

            bool active = _key == _property.value;

            if (_invert)
            {
                active = !active;
            }

            gameObject.SetActive(active);
        }
    }
}