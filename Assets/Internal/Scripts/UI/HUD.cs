using Core.CashRewardSystem;
using Core.InventorySystem;

using UnityEngine;

using Zenject;


namespace Core.UI
{

    public sealed class HUD : MonoBehaviour
    {
        [SerializeField] private CashRewardPresenter _cashRewardPresenter;
        [SerializeField] private CashPresenter _cashPresenter;

        [Inject]
        public void Constuct(CashRewardFacade cashRewardFacade, Inventory inventory)
        {
            _cashRewardPresenter.Init(cashRewardFacade);
            _cashPresenter.Init(inventory.CashHandler);
        }
    }

}