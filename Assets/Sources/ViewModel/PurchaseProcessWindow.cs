using Sources.ViewModel.Properties;
using UnityEngine;

namespace Sources.ViewModel
{
    public class PurchaseProcessWindow : MonoBehaviour
    {
        private readonly StringProperty _windowText = new();
        private readonly BoolProperty _operationProcess = new();
        
        public void Show()
        {
            GameModel.OperationComplete += OperationComplete;
            gameObject.SetActive(true);

            _operationProcess.value = true;
            _windowText.value = "ОБРАБОТКА ПОКУПКИ";
        }

        public void Hide()
        {
            GameModel.OperationComplete -= OperationComplete;
            gameObject.SetActive(false);
        }
        
        private void OperationComplete(GameModel.OperationResult result)
        {
            if (result.IsSuccess)
            {
                _windowText.value = "СПАСИБО ЗА ПОКУПКУ";   
            }
            else
            {
                _windowText.value = result.ErrorDescription;
            }

            _operationProcess.value = false;
        }
    }
}