using Core.InventorySystem;
using Core.IO;

namespace Core.CashRewardSystem
{

    public class ManualCashRewarder : AbstractCashRewarder
    {
        private IInput _input;

        public ManualCashRewarder(CashRewardDataBundle dataBundle, Inventory inventory, IInput input):
            base(dataBundle, inventory.CashHandler)
        {
            _input = input;
        }

        public void Enable()
        {
            _input.OnClick += OnClick;
        }

        public void Disable()
        {
            _input.OnClick -= OnClick;
        }

        private void OnClick()
        {
            _cashHandler.Add(_dataBundle.RewardPerTap);
        }
    }

}