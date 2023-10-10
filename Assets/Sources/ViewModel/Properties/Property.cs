using System;

namespace Sources.ViewModel.Properties
{
    public abstract class Property<T> : IProperty
    {
        public event Action ValueChanged;
        
        public T value
        {
            get => _value;
            set => SetValue(value);
        }

        private T _value;

        private void SetValue(T newValue)
        {
            if (Equals(_value, newValue))
            {
                return;
            }
            
            _value = newValue;

            InvokeValueChanged();
        }

        private bool Equals(T firstValue, T secondValue)
        {
            return typeof(T).IsValueType ? firstValue.Equals(secondValue)
                : (firstValue == null && secondValue == null) || (firstValue != null && secondValue != null) && firstValue.Equals(secondValue);
        }

        private void InvokeValueChanged()
        {
            ValueChanged?.Invoke();
        }
    }
}