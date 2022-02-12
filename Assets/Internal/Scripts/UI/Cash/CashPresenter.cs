using UnityEngine;

namespace Core.UI
{

    public sealed class CashPresenter : MonoBehaviour
    {
        [SerializeField] private CashView _cashView;

        private CashHandler _cashHandler;

        public void Init(CashHandler cashHandler)
        {
            _cashHandler = cashHandler;
            _cashView.ChangeValue(_cashHandler.Cash);
        }

        private void OnEnable()
        {
            _cashHandler.CashChanged += OnCashChanged;
        }

        private void OnDisable()
        {
            _cashHandler.CashChanged -= OnCashChanged;
        }

        public void OnCashChanged(float cash)
        {
            _cashView.ChangeValue(_cashHandler.Cash);
        }
    }
}