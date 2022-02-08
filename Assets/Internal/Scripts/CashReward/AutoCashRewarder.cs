using Core.InventorySystem;

using UnityEngine;

using Zenject;

namespace Core.CashRewardSystem
{
    public class AutoCashRewarder : AbstractCashRewarder, ITickable
    {
        private float _expiredTime;
        private const float _frequency = 1f;

        public AutoCashRewarder(CashRewardDataBundle dataBundle, Inventory inventory) :
            base(dataBundle, inventory.CashHandler)
        {
            _expiredTime = 0;
        }

        public void Tick()
        {
            if (_expiredTime >= _frequency)
            {
                _expiredTime = 0;
                _cashHandler.Add(_dataBundle.Reward);
            }

            _expiredTime += Time.deltaTime;
        }
    }
}