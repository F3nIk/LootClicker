using Core.InventorySystem;
using Core.IO;

namespace Core.CashRewardSystem
{

    public class ManualCashRewarder : AbstractCashRewarder
    {
        private IInput _input;

        public ManualCashRewarder(CashRewardDataBundle cashRewardDataBundle, Inventory inventory, IInput input):
            base(inventory.CashHandler)
        {
            _reward = cashRewardDataBundle.RewardPerTap;
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
            _cashHandler.Add(_reward);
        }

        public void ChangeReward(float value)
        {
            _reward = value;
        }
    }

}