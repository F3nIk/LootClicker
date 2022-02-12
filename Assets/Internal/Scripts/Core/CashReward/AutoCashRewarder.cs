using Core.InventorySystem;

using UnityEngine;

using Zenject;

namespace Core.CashRewardSystem
{
    public class AutoCashRewarder : AbstractCashRewarder, ITickable
    {
        private float _expiredTime;
        private const float _frequency = 1f;

        public AutoCashRewarder(CashRewardDataBundle cashRewardDataBundle, Inventory inventory) :
            base(inventory.CashHandler)
        {
            _reward = cashRewardDataBundle.Reward;
            _expiredTime = 0;
        }

        public void Tick()
        {
            if (_expiredTime >= _frequency)
            {
                _expiredTime = 0;
                _cashHandler.Add(_reward);
            }

            _expiredTime += Time.deltaTime;
        }

        public void ChangeReward(float value)
        {
            _reward = value;
        }
    }
}