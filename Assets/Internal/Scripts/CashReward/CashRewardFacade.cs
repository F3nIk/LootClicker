using Core.InventorySystem;
using Core.IO;
using Core.ItemSystem;

using System;

using UnityEngine;

using Zenject;

namespace Core.CashRewardSystem
{

    public sealed class CashRewardFacade : MonoBehaviour, ISaveable
    {
        private AutoCashRewarder _autoCashRewarder;
        private ManualCashRewarder _manualCashRewarder;

        private CashRewardDataBundle _cashRewardDataBundle;
        private Inventory _inventory;

        private ISaver _saver;
        private CashRewardSaveableData _cashRewardSaveableData;

        public event Action<float> RewardRateChanged;

        public object SaveableObject => _cashRewardSaveableData;

        [Inject]
        public void Construct(
            CashRewardDataBundle cashRewardDataBundle,
            Inventory inventory,
            AutoCashRewarder autoCashRewarder,
            ManualCashRewarder manualCashRewarder,
            ISaver saver
            )
        {
            _inventory = inventory;
            _cashRewardDataBundle = cashRewardDataBundle;
            _autoCashRewarder = autoCashRewarder;
            _manualCashRewarder = manualCashRewarder;
            _saver = saver;
        }

        private void Awake()
        {
            Load();
        }

        private void OnEnable()
        {
            _manualCashRewarder.Enable();
            _inventory.EquipItemChanged += OnEquipedItemChanged;
        }

        private void OnDisable()
        {
            _manualCashRewarder.Disable();
            _inventory.EquipItemChanged -= OnEquipedItemChanged;
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnEquipedItemChanged(LootItemData item)
        {
            ChangeRewardRateValue(item.RewardRate);
        }

        private  void ChangeRewardRateValue(float rate)
        {
            _cashRewardSaveableData.rewardRate = rate;
            RewardRateChanged?.Invoke(rate);
        }

        private void Load()
        {
            _cashRewardSaveableData = new CashRewardSaveableData(_cashRewardDataBundle);

            if (_saver.Exists(this)) _saver.LoadOverwrite(this);
        }

        private void Save()
        {
            _saver.Save(this);
        }

        public string GetFileName()
        {
            return Application.persistentDataPath + "/CashReward.rja";
        }
    }
}