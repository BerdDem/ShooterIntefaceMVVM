using Sources.ViewModel.Properties.Interfaces;
using TMPro;
using UnityEngine;

namespace Sources.ViewModel.Bindings
{
    public class BoolChangeTextColorBinding : Binding<IBoolProperty>
    {
        [SerializeField] private Color _trueColor = Color.black;
        [SerializeField] private Color _falseColor = Color.red;

        private TextMeshProUGUI _textMeshPro;
        
        protected override void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            
            base.Awake();
        }

        protected override void OnUpdateValue()
        {
            base.OnUpdateValue();

            _textMeshPro.color = _property.value ? _trueColor : _falseColor;
        }
    }
}