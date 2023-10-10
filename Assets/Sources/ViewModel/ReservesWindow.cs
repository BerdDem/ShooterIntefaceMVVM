using System;
using Sources.ViewModel.Properties;
using UnityEngine;

namespace Sources.ViewModel
{
    public class ReservesWindow : MonoBehaviour
    {
        public enum CurrencyType
        {
            Coin,
            Credit
        }

        [SerializeField] private PurchaseProcessWindow _purchaseProcessWindow;
        
        private readonly IntProperty _medPackCount = new();
        private readonly IntProperty _armorPlateCount = new();
        
        private readonly IntProperty _medPackCoinCost = new();
        private readonly IntProperty _medPackCreditCost = new();
        private readonly IntProperty _armorPlateCoinCost = new();
        private readonly IntProperty _armorPlateCreditCost = new();

        private void Awake()
        {
            GameModel.ModelChanged += OnModelChange;

            OnModelChange();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void PurchaseMedPack(int resourceIndex)
        {
            CurrencyType currencyType = (CurrencyType) resourceIndex;

            if (currencyType == CurrencyType.Coin)
            {
                GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
            }
            else
            {
                GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.Medpack);
            }
            
            _purchaseProcessWindow.Show();
        }

        public void PurchaseArmorPlate(int resourceIndex)
        {
            CurrencyType currencyType = (CurrencyType) resourceIndex;

            if (currencyType == CurrencyType.Coin)
            {
                GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.ArmorPlate);
            }
            else
            {
                GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
            }
            
            _purchaseProcessWindow.Show();
        }
        
        private void OnModelChange()
        {
            _medPackCount.value = GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack);
            _armorPlateCount.value = GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate);

            GameModel.ConsumableConfig medPackConfig = GameModel.ConsumablesPrice[GameModel.ConsumableTypes.Medpack];
            _medPackCoinCost.value = medPackConfig.CoinPrice;
            _medPackCreditCost.value = medPackConfig.CreditPrice;
            
            GameModel.ConsumableConfig armorConfig = GameModel.ConsumablesPrice[GameModel.ConsumableTypes.ArmorPlate];
            _armorPlateCoinCost.value = armorConfig.CoinPrice;
            _armorPlateCreditCost.value = armorConfig.CreditPrice;
        }

        private void OnDestroy()
        {
            GameModel.ModelChanged -= OnModelChange;
        }
    }
}