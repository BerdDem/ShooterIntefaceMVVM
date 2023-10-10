using Sources.ViewModel.Properties;
using Sources.ViewModel.Properties.Interfaces;
using TMPro;
using UnityEngine;

namespace Sources.ViewModel.Bindings
{
    public class TextBinding : Binding<IStringProperty>
    {
        private TextMeshProUGUI _textMeshPro;
        
        protected override void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            
            base.Awake();
        }

        protected override void OnUpdateValue()
        {
            _textMeshPro.text = _property.value;
        }
    }
}