using Core.CashRewardSystem;

using UnityEngine;

namespace Core.UI
{

    public sealed class CashRewardPresenter : MonoBehaviour
    {
        [SerializeField] private CashRewardView _cashRewardView;

        private CashRewardFacade _cashRewardFacade;

        public void Init(CashRewardFacade cashRewardFacade)
        {
            _cashRewardFacade = cashRewardFacade;
        }

        private void OnEnable()
        {
            _cashRewardFacade.RewardRateChanged += OnRewardRateChanged;
        }

        private void OnDisable()
        {
            _cashRewardFacade.RewardRateChanged -= OnRewardRateChanged;
        }

        private void OnRewardRateChanged(float rate)
        {
            _cashRewardView.ChangeValue(rate);
        }
    }
}