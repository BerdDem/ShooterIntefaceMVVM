using System;
using System.Reflection;
using Sources.ViewModel.Properties;
using UnityEngine;

namespace Sources.ViewModel.Bindings
{
    public abstract class Binding<T> : MonoBehaviour where T : class, IProperty
    {
        [SerializeField] private MonoBehaviour _propertySource;
        [SerializeField] private string _propertyName;

        protected T _property { get; private set; }
        
        protected virtual void Awake()
        {
            InitializeProperty();
            Bind();
            UpdateValue();
        }

        private void InitializeProperty()
        {
            if (_propertySource == null)
            {
                Debug.LogError("PropertySource haven't link");
                
                return;
            }

            if (string.IsNullOrEmpty(_propertyName))
            {
                Debug.LogError("PropertyName is null or empty");
                
                return;
            }

            _property = null;

            Type propertyType = _propertySource.GetType();
            FieldInfo elementField = propertyType.GetField(_propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            object elementObject = elementField?.GetValue(_propertySource);
            
            _property = (T)elementObject;
        }
        
        protected virtual void OnUpdateValue() { }

        private void Bind()
        {
            _property.ValueChanged += UpdateValue;
        }

        private void Unbind()
        {
            _property.ValueChanged -= UpdateValue;
        }

        private void UpdateValue()
        {
            OnUpdateValue();
        }

        private void OnDestroy()
        {
            Unbind();
        }
    }
}