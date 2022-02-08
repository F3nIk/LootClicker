using Core.InventorySystem;
using Core.IO;
using Core.ItemSystem;

using System;

using UnityEngine;

namespace Core
{

    public sealed class LootBox : ISaveable
    {
        private LootBoxDataBundle _dataBundle;
        private Inventory _inventory;

        private ISaver _saver;
        private LootBoxSaveableData _lootBoxSaveableData;

        public LootBox(LootBoxDataBundle dataBundle, Inventory inventory, ISaver saver)
        {
            _dataBundle = dataBundle;
            _inventory = inventory;
            _saver = saver;

            _lootBoxSaveableData = new LootBoxSaveableData();
        }

       

        public object SaveableObject => _lootBoxSaveableData;

        public bool CanOpen() => _inventory.CashHandler.IsEnough(GetCurrentPrice());

        public LootItemData Open()
        {
            LootItemData item = _dataBundle.GetLoot();
            _inventory.CashHandler.Take(GetCurrentPrice());
            _lootBoxSaveableData.totalOpened++;
            _inventory.AddItem(item);

            return item;
        }


        public void Save()
        {
            _saver.Save(this);
        }

        public void Load()
        {
            if (_saver.Exists(this))
            {
                _saver.LoadOverwrite(this);
            }
        }

        public string GetFileName()
        {
            return Application.persistentDataPath + "/LootBox.rja";
        }

        public float GetCurrentPrice()
        {
            return _lootBoxSaveableData.totalOpened == 0 ? _dataBundle.Cost :
                 _lootBoxSaveableData.totalOpened * _dataBundle.Cost * _dataBundle.AdditionalCostPerOpen;
        }
    }
}