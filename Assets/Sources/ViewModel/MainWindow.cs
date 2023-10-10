using System;
using Sources.ViewModel.Properties;
using Sources.ViewModel.Properties.Interfaces;
using UnityEngine;

namespace Sources.ViewModel
{
    public class MainWindow : MonoBehaviour
    {
        private readonly IntProperty _coinCount = new();
        private readonly IntProperty _creditCount = new();

        private readonly IntProperty _medPackCount = new();
        private readonly IntProperty _armorPlateCount = new();

        private void Awake()
        {
            GameModel.ModelChanged += OnModelChange;

            OnModelChange();
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