using Sources.ViewModel.Properties;
using UnityEngine;

namespace Sources.ViewModel
{
    public class MainWindow : MonoBehaviour
    {
        [SerializeField] private ReservesWindow _reservesWindow;
        [SerializeField] private ExchangeWindow _exchangeWindow;
        
        private readonly IntProperty _coinCount = new();
        private readonly IntProperty _creditCount = new();

        private readonly IntProperty _medPackCount = new();
        private readonly IntProperty _armorPlateCount = new();

        private void Awake()
        {
            GameModel.ModelChanged += OnModelChange;

            OnModelChange();
        }

        public void OpenReserves()
        {
            _reservesWindow.Show();
        }

        public void OpenExchange()
        {
            _exchangeWindow.Show();
        }

        private void OnModelChange()
        {
            _coinCount.value = GameModel.CoinCount;
            _creditCount.value = GameModel.CreditCount;

            _medPackCount.value = GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack);
            _armorPlateCount.value = GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate);
        }

        private void OnDestroy()
        {
            GameModel.ModelChanged -= OnModelChange;
        }
    }
}