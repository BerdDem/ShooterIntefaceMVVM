using Sources.ViewModel.Properties;
using Sources.ViewModel.Properties.Interfaces;
using TMPro;
using UnityEngine;

namespace Sources.ViewModel
{
    public class ExchangeWindow : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject _errorConvertWindow;
        
        [SerializeField] private PurchaseProcessWindow _purchaseProcessWindow;

        private readonly IntProperty _coinToCreditExchangeRate = new();
        private readonly IntProperty _creditExchange = new();
        
        private readonly IntProperty _coinCount = new();
        private readonly IntProperty _creditCount = new();

        private readonly BoolProperty _validCoinsCount = new();

        private int _coinExchangeCount;

        private void Awake()
        {
            GameModel.ModelChanged += OnModelChange;
            _inputField.onValueChanged.AddListener(OnInputValueChange);
            
            OnModelChange();
            _coinToCreditExchangeRate.value = GameModel.CoinToCreditRate;
            _validCoinsCount.value = true;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _inputField.interactable = true;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _inputField.interactable = false;
        }

        public void Exchange()
        {
            if (!CorrectConvertValue())
            {
                _errorConvertWindow.SetActive(true);
                return;
            }
            
            GameModel.ConvertCoinToCredit(_coinExchangeCount);
            _purchaseProcessWindow.Show();
        }

        public void CloseErrorConvertWindow()
        {
            _errorConvertWindow.SetActive(false);
        }

        private bool CorrectConvertValue()
        {
            return _coinExchangeCount != 0 && _coinExchangeCount < GameModel.CoinCount;
        }

        private void OnInputValueChange(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                _coinExchangeCount = 0;
                _creditExchange.value = 0;
                _inputField.text = string.Empty;
                _validCoinsCount.value = true;
                return;
            }
            
            string filteredText = string.Empty;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c;
                }
            }
            
            _inputField.text = filteredText;

            _coinExchangeCount = int.Parse(filteredText);
            _creditExchange.value = _coinExchangeCount * GameModel.CoinToCreditRate;

            _validCoinsCount.value = _coinExchangeCount < GameModel.CoinCount;
        }
        
        private void OnModelChange()
        {
            _coinCount.value = GameModel.CoinCount;
            _creditCount.value = GameModel.CreditCount;
        }

        private void OnDestroy()
        {
            GameModel.ModelChanged -= OnModelChange;
        }
    }
}